using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerApp.Dto
{
    public class TenderBidSubmissionProductDto
    {
        public int TenderBidSubmissionProductId { get; set; }
        public int ProductId { get; set; }
        public decimal RecommendedPrice { get; set; }
        public decimal QuotedPrice { get; set; }
        public int Quantity { get; set; }
        public int TenderBidSubmissionId { get; set; }
        public TenderBidSubmissionDto TenderBidSubmission { get; set; }
    }
}
