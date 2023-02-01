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
    public class ClientController : ControllerBase
    {
        private readonly IClientApplication _clientApplication;
        public ClientController(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ClientDTO clientDTO)
        {
            if (clientDTO == null)
                return BadRequest();
            var response = await _clientApplication.Insert(clientDTO);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ClientDTO clientsDto)
        {
            if (clientsDto == null)
                return BadRequest();
            var response = await _clientApplication.Update(clientsDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> Delete(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
                return BadRequest();
            var response = await _clientApplication.Delete(clientId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _clientApplication.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> Get(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
                return BadRequest();
            var response = await _clientApplication.Get(clientId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}