using System;
using System.Collections.Generic;
using Intercorp.CEFReports.Domain.Entity;
using Intercorp.CEFReports.Infrastructure.Interface;
using Intercorp.CEFReports.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

namespace Intercorp.CEFReports.Infrastructure.Repository
{
    public class CuentaAnalisisRepository :ICuentaAnalisisRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CuentaAnalisisRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<CuentaAnalisis> ObtenerCuentaAnalisis(CuentaAnalisisRequest request)
        {
            CuentaAnalisis result;

            var arrCodPeriodo = request.ARGPERIODOS.Split(";");
            var lstPeriodo = new List<Periodo>();
            foreach (string strPeriodo in arrCodPeriodo)
            {
                var obePeriodo = new Periodo();
                obePeriodo.CodMetodizado = request.CODMETODIZADO;
                obePeriodo.CodPeriodo = strPeriodo;
                lstPeriodo.Add(obePeriodo);
            }

            XElement xmlElements = new XElement("METODIZADO", new XAttribute("CodMetodizado", request.CODMETODIZADO), lstPeriodo.Select(i => new XElement("PERIODO", new XAttribute("CodPeriodo", i.CodPeriodo))));

            using (var connection = _connectionFactory.GetIBCefSqlConnection)
            {
                var query = "up_CalcularCuentaAnalisisCabecera";
                var parameters = new DynamicParameters();
                parameters.Add("@argCodMetodizado", request.CODMETODIZADO);
                parameters.Add("@argMetodizadoXML", xmlElements.ToString());

                result = await connection.QuerySingleAsync<CuentaAnalisis>(query, param: parameters,
                   commandType: System.Data.CommandType.StoredProcedure);
                result.CuentaAnalisisDetalle = (List<CuentaAnalisisDetalle>)await ListarCuentaAnalisisDetalle(request.CODMETODIZADO, xmlElements.ToString(), request.ARGCODANALISIS, request.ARGCODEEFF);

                return result;
            }

        }
        public async Task<IEnumerable<CuentaAnalisisDetalle>> ListarCuentaAnalisisDetalle(int codMetodizado, string  metodizadoXml, int CodAnalisis, int CodEEF)
        {
            using (var connection = _connectionFactory.GetIBCefSqlConnection)
            {
                var query = "up_RPT_CEF_Metodizado";
                var parameters = new DynamicParameters();
                parameters.Add("@argCodMetodizado", codMetodizado);
                parameters.Add("@argMetodizadoXML", metodizadoXml);
                //parameters.Add("@argCodAnalisis", CodAnalisis);
                //parameters.Add("@argCodEEFF", CodEEF);
                var result = await connection.QueryAsync<CuentaAnalisisDetalle>(query, param: parameters, commandTimeout:0,
                    commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }

        }
    }
}
