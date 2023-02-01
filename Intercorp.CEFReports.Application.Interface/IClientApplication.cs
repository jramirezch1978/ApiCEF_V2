using System;
using System.Collections.Generic;
using System.Text;
using Intercorp.CEFReports.Transversal.Common;
using Intercorp.CEFReports.Application.DTO;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Application.Interface
{
    public interface IClientApplication
    {
        Task<Response<IEnumerable<ClientDTO>>> GetAll();
        Task<Response<bool>> Insert(ClientDTO clientDTO);
        Task<Response<bool>> Update(ClientDTO clientsDto);
        Task<Response<bool>> Delete(string clientId);
        Task<Response<ClientDTO>> Get(string clientId);
    }
}
