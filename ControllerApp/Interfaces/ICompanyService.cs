using ControllerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSystem.Models;

namespace TenderSystem.Services.Interfaces
{
    public interface ICompanyService
    {
        List<Company> GetCompanies();
        Company AddCompany(CompanyDto company);
        void EditCompany(CompanyDto company);
        StateOrgan AddStateOrgan(StateOrganDto stateOrganDto);
    }
}
