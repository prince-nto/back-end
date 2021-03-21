using AutoMapper;
using ControllerApp;
using ControllerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSystem.Models;

namespace TenderSystem.Services.Interfaces
{
    public class TenderService : ITenderService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public TenderService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public List<Tender> GetTenders()
        {
            return _databaseContext.Tenders.Where(t => t.isClosed == false).ToList();
        }
        public Tender AddNewTender(TenderDto tenderDto)
        {
            var tender = new Tender
            {
                Description = tenderDto.Description,
                OpenDate = tenderDto.OpenDate,
                CloseDate = tenderDto.CloseDate,
                ContactNo = tenderDto.ContactNo,
                EmailAddress = tenderDto.EmailAddress,
                StateOrganId = tenderDto.StateOrganId
            };
            _databaseContext.Tenders.Add(tender);
            _databaseContext.SaveChanges();

            return tender;
        }

        public void EditTender(TenderDto tenderBid)
        {
            var tender = _databaseContext.Tenders.Find(tenderBid.TenderId);

            tender.Description = tenderBid.Description;
            tender.OpenDate = tenderBid.OpenDate;
            tender.CloseDate = tenderBid.CloseDate;
            tender.ContactNo = tenderBid.ContactNo;
            tender.EmailAddress = tenderBid.EmailAddress;
            tender.StateOrganId = tenderBid.StateOrganId;

            _databaseContext.SaveChanges();
        }


        public TenderBidSubmission CaptureBidSubmission(TenderBidSubmissionDto bidSubmission)
        {
            var tenderBidSubmission = new TenderBidSubmission
            {
                CompanyName = bidSubmission.CompanyName,
                RegistrationNumber = bidSubmission.RegistrationNumber,
                TotalQuotation = bidSubmission.TotalQuotation,
                DateSubmitted = DateTime.Now,
                SumittedById = bidSubmission.SumittedById,
                TenderId = bidSubmission.TenderId
            };

            _databaseContext.TenderBidSubmissions.Add(tenderBidSubmission);
            _databaseContext.SaveChanges();

            TenderBidSubmissionProduct tenderBidSubmissionProduct = new TenderBidSubmissionProduct();
            foreach(var bidProduct in bidSubmission.TenderBidSubmissionProducts)
            {
                tenderBidSubmissionProduct.ProductId = bidProduct.ProductId;
                tenderBidSubmissionProduct.Quantity = bidProduct.Quantity;
                tenderBidSubmissionProduct.QuotedPrice = bidProduct.QuotedPrice;
                tenderBidSubmissionProduct.TenderBidSubmissionId = tenderBidSubmission.TenderBidSubmissionId;

                tenderBidSubmission.TenderBidSubmissionProducts.Add(tenderBidSubmissionProduct);
            }

            _databaseContext.SaveChanges();

            return tenderBidSubmission;
        }

        public void EditSubmitBid(TenderBidSubmissionDto bidSubmission)
        {
            throw new NotImplementedException();
        }

        public void EvaluationTenderBids(int tenderId)
        {
            var submittedTenders = _databaseContext.TenderBidSubmissions.Where(t => t.TenderId == tenderId).ToList();
        }

        public void CloseTender(TenderDto tenderDto)
        {
            var tender = _databaseContext.Tenders.Find(tenderDto.TenderId);

            tender.isClosed = true;
            _databaseContext.SaveChanges();

            EvaluationTenderBids(tenderDto.TenderId);
        }
    }
}
