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
    public class ReconciliacionPatrimonioController : ControllerBase
    {
        private readonly IReconciliacionPatrimonioApplication _reconciliacionPatrimonioApplication;
        public ReconciliacionPatrimonioController(IReconciliacionPatrimonioApplication reconciliacionPatrimonioApplication)
        {
            _reconciliacionPatrimonioApplication = reconciliacionPatrimonioApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerReconciliacionPatrimonio(ReconciliacionPatrimonioRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _reconciliacionPatrimonioApplication.ObtenerReconciliacionPatrimonio(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

        [HttpPost("slip/pdf")]
        public async Task<IActionResult> ObtenerReconciliacionPatrimonioPDF(ReconciliacionPatrimonioRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest();
            var response = await _reconciliacionPatrimonioApplication.ObtenerReconciliacionPatrimonioPDF(requestDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);

        }

    }
}