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
        public IActionResult Get(int id)
        {
            var results = _tenderService.GetTenderById(id);
           return Ok(results);
        }

        [HttpGet("evaluatedBids")]
        public IActionResult GetEvaluatedBids()
        {
            var results = _tenderService.GetEvaluatedTenders();
            return Ok(results);
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

        [HttpGet("getEligibleSuppliers/{id}")]
        public IActionResult GetEligibleSuppliers(int id)
        {
            var results = _tenderService.GetTenderEligibleSuppliers(id);
            return Ok(results);
        }

        [HttpPost("bidSubmission")]
        public IActionResult CaptureBidSubmission([FromBody] TenderBidSubmissionDto bidSubmission)
        {
            var results = _tenderService.CaptureBidSubmission(bidSubmission);
            return Ok(results);
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var results = _tenderService.GetProducts();
            return Ok(results);
        }

        // PUT api/<TenderController>/5
        [HttpPut]
        public void Put([FromBody]TenderDto tenderDto)
        {
            _tenderService.CloseTender(tenderDto);
        }

        // DELETE api/<TenderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
