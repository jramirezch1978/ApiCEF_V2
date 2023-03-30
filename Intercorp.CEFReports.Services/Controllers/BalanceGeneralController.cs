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
    public class BalanceGeneralController : ControllerBase
    {
        private readonly IBalanceGeneralApplication _balanceGeneralApplication;
        public BalanceGeneralController(IBalanceGeneralApplication balanceGeneralApplication)
        {
            _balanceGeneralApplication = balanceGeneralApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerBalanceGeneral(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _balanceGeneralApplication.ObtenerBalanceGeneral(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

        [HttpPost("slip/pdf")]
        public async Task<IActionResult> ObtenerBalanceGeneralPDF(CuentaAnalisisRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _balanceGeneralApplication.ObtenerBalanceGeneralPDF(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

    }
}