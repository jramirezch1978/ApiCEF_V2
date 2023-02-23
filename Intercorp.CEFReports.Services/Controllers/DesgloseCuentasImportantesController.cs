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
    public class DesgloseCuentasImportantesController : ControllerBase
    {
        private readonly IDesgloseCuentasImportantesApplication _desgloseCuentasImportantesApplication;
        public DesgloseCuentasImportantesController(IDesgloseCuentasImportantesApplication desgloseCuentasImportantesApplication)
        {
            _desgloseCuentasImportantesApplication = desgloseCuentasImportantesApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerDesgloseCuentasImportantes(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _desgloseCuentasImportantesApplication.ObtenerDesgloseCuentasImportantes(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

        [HttpGet("slip/pdf")]
        public async Task<IActionResult> ObtenerDesgloseCuentasImportantesPDF(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _desgloseCuentasImportantesApplication.ObtenerDesgloseCuentasImportantesPDF(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

    }
}