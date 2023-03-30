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
    public class FuentesUsosFondosController : ControllerBase
    {
        private readonly IFuentesUsosFondosApplication _fuentesUsosFondosApplication;
        public FuentesUsosFondosController(IFuentesUsosFondosApplication fuentesUsosFondosApplication)
        {
            _fuentesUsosFondosApplication = fuentesUsosFondosApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerFuentesUsosFondos(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _fuentesUsosFondosApplication.ObtenerFuentesUsosFondos(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

        [HttpPost("slip/pdf")]
        public async Task<IActionResult> ObtenerFuentesUsosFondosPDF(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _fuentesUsosFondosApplication.ObtenerFuentesUsosFondosPDF(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

    }
}