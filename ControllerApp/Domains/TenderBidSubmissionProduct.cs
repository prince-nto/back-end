using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderSystem.Models
{
    public class TenderBidSubmissionProduct
    {
        public int TenderBidSubmissionProductId {get; set; }
        public int ProductId { get; set; }
        public decimal RecommendedPrice { get; set; }
        public decimal QuotedPrice { get; set; }
        public int Quantity { get; set; }
        public int TenderBidSubmissionId { get; set; }
        public virtual TenderBidSubmission TenderBidSubmission { get; set; }
    }
}
