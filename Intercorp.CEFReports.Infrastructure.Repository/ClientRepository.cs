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
    public class ClientRepository :IClientRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ClientRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> Delete(string clientId)
        {
            using (var connection = _connectionFactory.GetMysqlConnection)
            {
                var query = "SP_ClientDelete";
                var parameters = new DynamicParameters();
                parameters.Add("p_clientid", clientId);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> Insert(Client client)
        {
            using (var connection = _connectionFactory.GetMysqlConnection)
            {
                var query = "SP_ClientInsert";
                var parameters = new DynamicParameters();
                parameters.Add("p_name", client.Name);
                parameters.Add("p_lastname", client.LastName);
                parameters.Add("p_phone", client.Phone);
                parameters.Add("p_address", client.Address);
                parameters.Add("p_email", client.Email);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> Update(Client client)
        {
            using (var connection = _connectionFactory.GetMysqlConnection)
            {
                var query = "SP_ClientUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("p_clientid", client.ClientId);
                parameters.Add("p_name", client.Name);
                parameters.Add("p_lastname", client.LastName);
                parameters.Add("p_address", client.Address);
                parameters.Add("p_phone", client.Phone);
                parameters.Add("p_email", client.Email);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<Client> Get(string clientId)
        {
            using (var connection = _connectionFactory.GetMysqlConnection)
            {
                var query = "SP_ClientGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("p_clientid", clientId);

                var client = await connection.QuerySingleAsync<Client>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return client;
            }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            using (var connection = _connectionFactory.GetMysqlConnection)
            {
                var query = "SP_ClientList";
                var clients = await connection.QueryAsync<Client>(query,
                    commandType: System.Data.CommandType.StoredProcedure);
                return clients;
            }

        }
    }
}
