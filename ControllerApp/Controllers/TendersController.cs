using ControllerApp.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSystem.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        private readonly ITenderService _tenderService;
        public TendersController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        // GET: api/<TenderController>
        [HttpGet]
        public IActionResult Get()
        {
            var results = _tenderService.GetTenders();
            return Ok(results);
        }

        // GET api/<TenderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TenderController>
        [HttpPost]
        public IActionResult CaptureNewTender([FromBody] TenderDto tenderDto)
        {
            if (tenderDto == null)
            {
                return BadRequest("Invalid model");
            }
                
            var result = _tenderService.AddNewTender(tenderDto);
            return Ok(result);
        }

        // PUT api/<TenderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TenderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
