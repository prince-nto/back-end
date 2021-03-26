using ControllerApp.Domains.Users;
using ControllerApp.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using TenderSystem.Models;

namespace TenderSystem.Services.Interfaces
{
    public interface ITenderService
    {
        List<Tender> GetTenders();
        List<Tender> GetEvaluatedTenders();
        Tender GetTenderById(int tenderId);
        Tender AddNewTender(TenderDto tenderBid);
        void EditTender(TenderDto tenderBid);
        TenderBidSubmission CaptureBidSubmission(TenderBidSubmissionDto bidSubmission);
        List<Product> GetProducts(); 
        void EditSubmitBid(TenderBidSubmissionDto bidSubmission);
        void EvaluationTenderBids(int tenderId);
        void CloseTender(TenderDto tenderDto);
        List<EligibleSupplier> GetTenderEligibleSuppliers(int tenderId);
        void SaveToDatabase(EligibleSupplier eligibleSupplier);
    }
}
