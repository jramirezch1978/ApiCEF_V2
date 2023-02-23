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
    public class CuentaAnalisisApplication : ICuentaAnalisisApplication
    {
        private readonly ICuentaAnalisisDomain _CuentaAnalisisDomain;
        private readonly IMapper _mapper;
        public CuentaAnalisisApplication(ICuentaAnalisisDomain CuentaAnalisisDomain, IMapper mapper)
        {
            _CuentaAnalisisDomain = CuentaAnalisisDomain;
            _mapper = mapper;
        }
        public async Task<Response<CuentaAnalisisDTO>> ObtenerCuentaAnalisis(CuentaAnalisisRequestDTO requestDTO)
        {
            var response = new Response<CuentaAnalisisDTO>();
            try
            {
                var request = _mapper.Map<CuentaAnalisisRequest>(requestDTO);

                var result = await _CuentaAnalisisDomain.ObtenerCuentaAnalisis(request);
                response.Data = _mapper.Map<CuentaAnalisisDTO>(result);
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
        public async Task<Response<String>> ObtenerCuentaAnalisisPDF(CuentaAnalisisRequestDTO requestDTO)
        {
            var response = new Response<String>();
            try
            {
                var request = _mapper.Map<CuentaAnalisisRequest>(requestDTO);
                var result = await _CuentaAnalisisDomain.ObtenerCuentaAnalisis(request);
               
                if (result != null)
                {
                    var archivo = new SlipPDFHelper().GenerarSLIP(result, "CuentaAnalisis");
                    response.Data = Convert.ToBase64String(archivo);
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
