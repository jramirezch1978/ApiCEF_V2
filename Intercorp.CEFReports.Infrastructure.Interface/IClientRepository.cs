using Intercorp.CEFReports.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Infrastructure.Interface
{
    public interface IClientRepository
    {
        Task<bool> Insert(Client client);
        Task<bool> Update(Client client);
        Task<bool> Delete(string clientId);
        Task<Client> Get(string clientId);
        Task<IEnumerable<Client>> GetAll();
    }
}
