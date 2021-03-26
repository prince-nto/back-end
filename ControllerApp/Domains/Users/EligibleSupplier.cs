using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSystem.Models;

namespace ControllerApp.Domains.Users
{
    public class EligibleSupplier
    {
        public int EligibleSupplierId { get; set; }
        public DateTime DateEvaluated { get; set; }
        public int Score { get; set; }
        public decimal InflationRate { get; set; }
        public int TenderId { get; set; }
        public virtual Tender Tender { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
