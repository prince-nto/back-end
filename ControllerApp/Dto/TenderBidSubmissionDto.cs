using ControllerApp.TempModels.Users;
using System;
using System.Collections.Generic;
using TenderSystem.Models;

namespace ControllerApp.Dto
{
    public class TenderBidSubmissionDto
    {
        public int TenderBidSubmissionId { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal TotalQuotation { get; set; }
        public int TenderId { get; set; }
        public Tender Tender { get; set; }
        public DateTime DateSubmitted { get; set; }
        public  List<TenderBidSubmissionProductDto> TenderBidProducts { get; set; }
    }
}
