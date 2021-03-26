using ControllerApp.Domains.Users;
using System;
using System.Collections.Generic;

namespace TenderSystem.Models
{
    public class TenderBidSubmission
    {
        public int TenderBidSubmissionId { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal TotalQuotation { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int TenderId { get; set; }
        public Tender Tender { get; set; }
        public virtual ICollection<TenderBidSubmissionProduct> TenderBidSubmissionProducts { get; set; }
    }
}
