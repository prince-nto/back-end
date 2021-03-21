
using AutoMapper;
using ControllerApp;
using ControllerApp.Dto;
using System.Collections.Generic;
using TenderSystem.Models;
using TenderSystem.Services.Interfaces;
using System.Linq;

namespace TenderSystem.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public CompanyService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public Company AddCompany(CompanyDto companyDto)
        {
            Company company = new Company
            {
                CompanyId = companyDto.CompanyId,
                Name = companyDto.Name,
                VatNo = companyDto.VatNo,
                Registration = companyDto.Registration,
                PhysicalAddress1 = companyDto.PhysicalAddress1,
                PhysicalAddress2 = companyDto.PhysicalAddress2,
                Suburb = companyDto.Suburb,
                Province = companyDto.Province,
                PostalCode = companyDto.PostalCode
            };

            _databaseContext.Companies.Add(company);
            _databaseContext.SaveChanges();

            return company;
        }


        public void EditCompany(CompanyDto companyDto)
        {
            Company company = _databaseContext.Companies.Find(companyDto.CompanyId);

            company.Name = companyDto.Name;
            company.VatNo = companyDto.VatNo;
            company.Registration = companyDto.Registration;
            company.PhysicalAddress1 = companyDto.PhysicalAddress1;
            company.PhysicalAddress2 = companyDto.PhysicalAddress2;
            company.Suburb = companyDto.Suburb;
            company.Province = companyDto.Province;
            company.PostalCode = companyDto.PostalCode;

            _databaseContext.SaveChanges();
        }

        public List<Company> GetCompanies()
        {
            return _databaseContext.Companies.ToList();
        }

        public StateOrgan AddStateOrgan(StateOrganDto stateOrganDto)
        {
            var stateOrgan = new StateOrgan
            {
                Name = stateOrganDto.Name,
                PhysicalAddress1 = stateOrganDto.PhysicalAddress1,
                PhysicalAddress2 = stateOrganDto.PhysicalAddress2,
                Province = stateOrganDto.Province,
                Region = stateOrganDto.Region,
                PostalCode = stateOrganDto.PostalCode,
                Suburb = stateOrganDto.Suburb
            };

            _databaseContext.Add(stateOrgan);
            _databaseContext.SaveChanges();

            return stateOrgan;
        }
    }
}
