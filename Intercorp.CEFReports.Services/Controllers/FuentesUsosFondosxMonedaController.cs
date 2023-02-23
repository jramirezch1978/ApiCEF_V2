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
    public class FuentesUsosFondosxMonedaController : ControllerBase
    {
        private readonly IFuentesUsosFondosxMonedaApplication _fuentesUsosFondosxMonedaApplication;
        public FuentesUsosFondosxMonedaController(IFuentesUsosFondosxMonedaApplication fuentesUsosFondosxMonedaApplication)
        {
            _fuentesUsosFondosxMonedaApplication = fuentesUsosFondosxMonedaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerFuentesUsosFondosxMoneda(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _fuentesUsosFondosxMonedaApplication.ObtenerFuentesUsosFondosxMoneda(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

        [HttpGet("slip/pdf")]
        public async Task<IActionResult> ObtenerFuentesUsosFondosxMonedaPDF(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _fuentesUsosFondosxMonedaApplication.ObtenerFuentesUsosFondosxMonedaPDF(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

    }
}