using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Intercorp.CEFReports.Application.DTO;
using Intercorp.CEFReports.Application.Interface;

namespace Intercorp.CEFReports.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoGananciaPerdidaController : ControllerBase
    {
        private readonly IEstadoGananciaPerdidaApplication _estadoGananciaPerdidaApplication;
        public EstadoGananciaPerdidaController(IEstadoGananciaPerdidaApplication estadoGananciaPerdidaApplication)
        {
            _estadoGananciaPerdidaApplication = estadoGananciaPerdidaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEstadoGananciaPerdida(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _estadoGananciaPerdidaApplication.ObtenerEstadoGananciaPerdida(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

        [HttpGet("slip/pdf")]
        public async Task<IActionResult> ObtenerEstadoGananciaPerdidaPDF(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _estadoGananciaPerdidaApplication.ObtenerEstadoGananciaPerdidaPDF(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

    }
}