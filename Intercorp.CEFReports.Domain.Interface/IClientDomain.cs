using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Intercorp.CEFReports.Domain.Entity;

namespace Intercorp.CEFReports.Domain.Interface
{
    public interface IClientDomain
    {
        Task<bool> Insert(Client client);
        Task<bool> Update(Client client);
        Task<bool> Delete(string clientId);
        Task<Client> Get(string clientId);
        Task<IEnumerable<Client>> GetAll();
    }
}
