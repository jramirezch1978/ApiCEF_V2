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
    public class RatiosFinancierosController : ControllerBase
    {
        private readonly IRatiosFinancierosApplication _ratiosFinancierospplication;
        public RatiosFinancierosController(IRatiosFinancierosApplication ratiosFinancierosApplication)
        {
            _ratiosFinancierospplication = ratiosFinancierosApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerRatiosFinancieros(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _ratiosFinancierospplication.ObtenerRatiosFinancieros(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

        [HttpPost("slip/pdf")]
        public async Task<IActionResult> ObtenerRatiosFinancierosPDF(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _ratiosFinancierospplication.ObtenerRatiosFinancierosPDF(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

    }
}