using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderSystem.Models
{
    public class StateOrgan
    {
        public int StateOrganId { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string PhysicalAddress1 { get; set; }
        public string PhysicalAddress2 { get; set; }
        public string Suburb { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
    }
}
