using System;
using Intercorp.CEFReports.Domain.Interface;
using Intercorp.CEFReports.Domain.Entity;
using Intercorp.CEFReports.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Domain.Core
{
    public class ClientDomain : IClientDomain
    {
        private readonly IClientRepository _clientRepository;

        public ClientDomain(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Delete(string clientId)
        {
            return await _clientRepository.Delete(clientId);
        }

        public async Task<Client> Get(string clientId)
        {
            return await _clientRepository.Get(clientId);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<bool> Insert(Client client)
        {
            return await _clientRepository.Insert(client);
        }

        public async Task<bool> Update(Client client)
        {
            return await _clientRepository.Update(client);
        }
    }
}
