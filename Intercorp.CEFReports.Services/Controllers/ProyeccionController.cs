using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Intercorp.CEFReports.Application.DTO;
using Intercorp.CEFReports.Application.Interface;
using Microsoft.AspNetCore.Hosting;

namespace Intercorp.CEFReports.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyeccionController : ControllerBase
    {
        private readonly IProyeccionApplication _proyeccionApplication;
        public ProyeccionController(IProyeccionApplication proyeccionApplication)
        {
            _proyeccionApplication = proyeccionApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProyeccion(ProyeccionRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _proyeccionApplication.ObtenerProyeccion(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }
        [HttpGet("slip/pdf")]
        public async Task<IActionResult> ObtenerProyeccionPDF(ProyeccionRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _proyeccionApplication.ObtenerProyeccionPDF(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }


    }
}