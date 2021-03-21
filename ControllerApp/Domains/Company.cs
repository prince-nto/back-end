using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderSystem.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string VatNo { get; set; }
        public string Registration { get; set; }
        public string PhysicalAddress1 { get; set; }
        public string PhysicalAddress2 { get; set; }
        public string Suburb { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public int ContactPersonId { get; set; }
        public virtual ICollection<CompanyUser> ContactPersons { get; set; }
    }
}
