using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerApp.Dto.Users
{
    public class EligibleSupplierDto
    {
        public int EligibleSupplierId { get; set; }
        public DateTime DateEvaluated { get; set; }
        public int Score { get; set; }
        public decimal InflationRate { get; set; }
        public int TenderId { get; set; }
        public TenderDto Tender { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
