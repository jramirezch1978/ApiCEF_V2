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
    public class BalanceGeneralApplication : IBalanceGeneralApplication
    {
        private readonly ICuentaAnalisisDomain _cuentaAnalisisDomain;
        private readonly IMapper _mapper;
        public BalanceGeneralApplication(ICuentaAnalisisDomain cuentaAnalisisDomain, IMapper mapper)
        {
            _cuentaAnalisisDomain = cuentaAnalisisDomain;
            _mapper = mapper;
        }
        public async Task<Response<CuentaAnalisisDTO>> ObtenerBalanceGeneral(CuentaAnalisisRequestDTO requestDTO)
        {
            var response = new Response<CuentaAnalisisDTO>();
            try
            {
                var request = _mapper.Map<CuentaAnalisisRequest>(requestDTO);

                var result = await _cuentaAnalisisDomain.ObtenerCuentaAnalisis(request);
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
        public async Task<Response<String>> ObtenerBalanceGeneralPDF(CuentaAnalisisRequestDTO requestDTO)
        {
            var response = new Response<String>();
            try
            {
                var request = _mapper.Map<CuentaAnalisisRequest>(requestDTO);
                var result = await _cuentaAnalisisDomain.ObtenerCuentaAnalisis(request);
               
                if (result != null)
                {
                    var archivo = new SlipPDFHelper().GenerarSLIP(result, "BalanceGeneral");
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
