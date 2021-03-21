using ControllerApp.Dto;
using System.Collections.Generic;
using TenderSystem.Models;

namespace TenderSystem.Services.Interfaces
{
    public interface ITenderService
    {
        List<Tender> GetTenders();
        Tender AddNewTender(TenderDto tenderBid);
        void EditTender(TenderDto tenderBid);
        TenderBidSubmission CaptureBidSubmission(TenderBidSubmissionDto bidSubmission);
        void EditSubmitBid(TenderBidSubmissionDto bidSubmission);
        void EvaluationTenderBids(int tenderId);
        void CloseTender(TenderDto tenderDto);
    }
}
