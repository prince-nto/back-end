using ControllerApp.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSystem.Models;
using TenderSystem.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _companyService.GetCompanies();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult AddCompany([FromBody]CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("Invalid model");
            }
            var result = _companyService.AddCompany(companyDto);

            return Ok(result);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("Bad Request, contact administrator");
            }

            _companyService.EditCompany(companyDto);

            return NoContent();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("stateOrganAdd")]
        public IActionResult AddStateOrgan([FromBody] StateOrganDto stateOrganDto)
        {
            if (stateOrganDto == null)
            {
                return BadRequest("Invalid model");
            }
            var result = _companyService.AddStateOrgan(stateOrganDto);

            return Ok(result);
        }

        [HttpGet("getStateOrgan/{id}")]
        public IActionResult GetStateOrgan(int id)
        {
            var result = _companyService.GetStateOrgan(id);

            return Ok(result);
        }

    }
}
