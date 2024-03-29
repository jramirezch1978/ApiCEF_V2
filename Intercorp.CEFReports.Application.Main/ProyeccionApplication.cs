﻿using System;
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
    public class ProyeccionApplication : IProyeccionApplication
    {
        private readonly IProyeccionDomain _ProyeccionDomain;
        private readonly IMapper _mapper;
        public ProyeccionApplication(IProyeccionDomain proyeccionDomain, IMapper mapper)
        {
            _ProyeccionDomain = proyeccionDomain;
            _mapper = mapper;
        }
        public async Task<Response<ProyeccionDTO>> ObtenerProyeccion(ProyeccionRequestDTO requestDTO)
        {
            var response = new Response<ProyeccionDTO>();
            try
            {
                var request = _mapper.Map<ProyeccionRequest>(requestDTO);

                var result = await _ProyeccionDomain.ObtenerProyeccion(request);
                response.Data = _mapper.Map<ProyeccionDTO>(result);
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
        public async Task<Response<String>> ObtenerProyeccionPDF(ProyeccionRequestDTO requestDTO)
        {
            var response = new Response<String>();
            try
            {
                var request = _mapper.Map<ProyeccionRequest>(requestDTO);
                var result = await _ProyeccionDomain.ObtenerProyeccion(request);

                if (result != null)
                {
                    var archivo = new SlipPDFHelper().GenerarSLIP(result, "Proyeccion");
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
