﻿using System;
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
    public class ReconciliacionPatrimonioRepository :IReconciliacionPatrimonioRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ICuentaAnalisisRepository _cuentaAnalisisRepository;
        public ReconciliacionPatrimonioRepository(IConnectionFactory connectionFactory, ICuentaAnalisisRepository cuentaAnalisisRepository)
        {
            _connectionFactory = connectionFactory;
            _cuentaAnalisisRepository = cuentaAnalisisRepository;
        }
        public async Task<ReconciliacionPatrimonio> ObtenerReconciliacionPatrimonio(ReconciliacionPatrimonioRequest request)
        {
            ReconciliacionPatrimonio result;

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

                 result = await connection.QuerySingleAsync<ReconciliacionPatrimonio>(query, param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
                result.CuentaAnalisis = (List<CuentaAnalisisDetalle>)await _cuentaAnalisisRepository.ListarCuentaAnalisisDetalle(request.CODMETODIZADO, xmlElements.ToString(), 2, 3);

                return result;
            }

        }
    }
}
