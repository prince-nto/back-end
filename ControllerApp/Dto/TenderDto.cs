using ControllerApp.Dto.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerApp.Dto
{
    public class TenderDto
    {
        public int TenderId { get; set; }
        public string BidNo { get; set; }
        public string Description { get; set; }
        public bool isClosed { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public int StateOrganId { get; set; }
        public StateOrganDto StateOrgan { get; set; }
        public List<EligibleSupplierDto> EligibleSuppliers { get; set; }
    }
}
