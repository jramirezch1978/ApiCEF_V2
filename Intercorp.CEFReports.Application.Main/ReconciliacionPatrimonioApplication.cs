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
    public class ReconciliacionPatrimonioApplication : IReconciliacionPatrimonioApplication
    {
        private readonly IReconciliacionPatrimonioDomain _reconciliacionPatrimonioDomain;
        private readonly IMapper _mapper;
        public ReconciliacionPatrimonioApplication(IReconciliacionPatrimonioDomain reconciliacionPatrimonioDomain, IMapper mapper)
        {
            _reconciliacionPatrimonioDomain = reconciliacionPatrimonioDomain;
            _mapper = mapper;
        }
        public async Task<Response<ReconciliacionPatrimonioDTO>> ObtenerReconciliacionPatrimonio(ReconciliacionPatrimonioRequestDTO requestDTO)
        {
            var response = new Response<ReconciliacionPatrimonioDTO>();
            try
            {
                var request = _mapper.Map<ReconciliacionPatrimonioRequest>(requestDTO);

                var result = await _reconciliacionPatrimonioDomain.ObtenerReconciliacionPatrimonio(request);
                response.Data = _mapper.Map<ReconciliacionPatrimonioDTO>(result);
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
        public async Task<Response<String>> ObtenerReconciliacionPatrimonioPDF(ReconciliacionPatrimonioRequestDTO requestDTO)
        {
            var response = new Response<String>();
            try
            {
                var request = _mapper.Map<ReconciliacionPatrimonioRequest>(requestDTO);
                var result = await _reconciliacionPatrimonioDomain.ObtenerReconciliacionPatrimonio(request);
               
                if (result != null)
                {
                    var archivo = new SlipPDFHelper().GenerarSLIP(result, "ReconciliacionPatrimonio");
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
