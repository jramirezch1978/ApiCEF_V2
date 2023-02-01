using System;
using System.Collections.Generic;
using Intercorp.CEFReports.Domain.Entity;
using Intercorp.CEFReports.Infrastructure.Interface;
using Intercorp.CEFReports.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Infrastructure.Repository
{
    public class ProyeccionRepository :IProyeccionRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProyeccionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Proyeccion> ObtenerProyeccion(ProyeccionRequest request)
        {
            Proyeccion result;
            using (var connection = _connectionFactory.GetIBCefSqlConnection)
            {
                var query = "up_RPT_CEF_Proyecciones_Cabecera";
                var parameters = new DynamicParameters();
                parameters.Add("@CODMETODIZADO", request.CODMETODIZADO);
                parameters.Add("@ARGPERIODOS", request.ARGPERIODOS);
                parameters.Add("@ARGPERPROY", request.ARGPERPROY);

                 result = await connection.QuerySingleAsync<Proyeccion>(query, param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
                result.ProyeccionDetalle = (List<ProyeccionDetalle>)await ListarProyeccionesDetalle(request);

                return result;
            }

        }

        public async Task<IEnumerable<ProyeccionDetalle>> ListarProyeccionesDetalle(ProyeccionRequest request)
        {
            using (var connection = _connectionFactory.GetIBCefSqlConnection)
            {
                var query = "up_RPT_CEF_Proyecciones_Detalle";
                var parameters = new DynamicParameters();

                parameters.Add("@CODMETODIZADO", request.CODMETODIZADO);
                parameters.Add("@ARGPERIODOS", request.ARGPERIODOS);
                parameters.Add("@ARGPERPROY", request.ARGPERPROY);

                var result = await connection.QueryAsync<ProyeccionDetalle>(query, param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }

        }
    }
}
