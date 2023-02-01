using System;
using Intercorp.CEFReports.Application.Interface;
using Intercorp.CEFReports.Domain.Interface;
using AutoMapper;
using Intercorp.CEFReports.Application.DTO;
using Intercorp.CEFReports.Transversal.Common;
using System.Collections.Generic;
using Intercorp.CEFReports.Domain.Entity;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Application.Main
{
    public class ClientApplication : IClientApplication
    {
        private readonly IClientDomain _clientDomain;
        private readonly IMapper _mapper;

        public ClientApplication(IClientDomain clientDomain, IMapper mapper)
        {
            _clientDomain = clientDomain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ClientDTO>>> GetAll()
        {
            var response = new Response<IEnumerable<ClientDTO>>();
            try
            {
                var clients = await _clientDomain.GetAll();
                response.Data =  _mapper.Map<IEnumerable<ClientDTO>>(clients);
                if(response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Si hay data";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }


        public async Task<Response<bool>> Insert(ClientDTO clientDTO)
        {
            var response = new Response<bool>();
            try
            {
                var client = _mapper.Map<Client>(clientDTO);
                response.Data = await _clientDomain.Insert(client);
                if(response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Inserto!";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Update(ClientDTO clientDto)
        {
            var response = new Response<bool>();
            try
            {
                var client = _mapper.Map<Client>(clientDto);
                response.Data = await _clientDomain.Update(client);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Delete(string clientId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _clientDomain.Delete(clientId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<ClientDTO>> Get(string clientId)
        {
            var response = new Response<ClientDTO>();
            try
            {
                var client = await _clientDomain.Get(clientId);
                response.Data = _mapper.Map<ClientDTO>(client);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
