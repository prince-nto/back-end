using AutoMapper;
using ControllerApp;
using ControllerApp.Domains.Users;
using ControllerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            var tenders = _databaseContext.Tenders.Where(t => t.isClosed == false).ToList();

            foreach(var tender in tenders)
            {
                var stateOrgan = _databaseContext.StateOrgans.Find(tender.StateOrganId);
                tender.StateOrgan = stateOrgan;

        }

            return tenders;
        }

        public Tender GetTenderById(int tenderId)
        {
            var tender = _databaseContext.Tenders.Find(tenderId);
            var stateOrgan = _databaseContext.StateOrgans.Find(tender.StateOrganId);

            tender.StateOrgan = stateOrgan;

            return tender;
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

        public List<Tender> GetEvaluatedTenders()
        {
            var tenders = _databaseContext.Tenders.Where(t => t.isClosed == true).ToList();

            foreach (var tender in tenders)
            {
                var stateOrgan = _databaseContext.StateOrgans.Find(tender.StateOrganId);
                tender.StateOrgan = stateOrgan;

            }

            return tenders;
        }

        public TenderBidSubmission CaptureBidSubmission(TenderBidSubmissionDto bidSubmission)
        {
            var tenderBidSubmission = new TenderBidSubmission
            {
                CompanyName = bidSubmission.CompanyName,
                RegistrationNumber = bidSubmission.RegistrationNumber,
                TotalQuotation = bidSubmission.TotalQuotation,
                DateSubmitted = DateTime.Now,
                TenderId = bidSubmission.TenderId
            };

            _databaseContext.TenderBidSubmissions.Add(tenderBidSubmission);
            _databaseContext.SaveChanges();
            tenderBidSubmission.TenderBidSubmissionProducts = new List<TenderBidSubmissionProduct>();
            TenderBidSubmissionProduct tenderBidSubmissionProduct = new TenderBidSubmissionProduct();
            foreach(var bidProduct in bidSubmission.TenderBidProducts)
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


        public List<Product> GetProducts()
        {
            return _databaseContext.Products.ToList();
        }
        public void EditSubmitBid(TenderBidSubmissionDto bidSubmission)
        {
            throw new NotImplementedException();
        }

        public void EvaluationTenderBids(int tenderId)
        {
            var tender = _databaseContext.Tenders.Find(tenderId);
            var submittedTenders = _databaseContext.TenderBidSubmissions.Where(t => t.TenderId == tenderId).ToList();
            EligibleSupplier eligibleSupplier = new EligibleSupplier();
            tender.EligibleSuppliers = new List<EligibleSupplier>();

            var eligibleSuppliers = new List<EligibleSupplier>();

            decimal totProductQtAmt = 0;
            decimal totProductRecAmt = 0;
            decimal priceDifference = 0;
            var tasks = new List<Task>();

            foreach (var tenderBid in submittedTenders)
            {
                var tenderBidProducts = _databaseContext.TenderBidSubmissionProducts.Where(t => t.TenderBidSubmissionId == tenderBid.TenderBidSubmissionId).ToList();

                foreach(var product in tenderBidProducts)
                {
                    var prod = _databaseContext.Products.Find(product.ProductId);
                    product.RecommendedPrice = prod.ProductPrice;
                    totProductQtAmt = product.QuotedPrice * product.Quantity;
                    totProductRecAmt = product.RecommendedPrice * product.Quantity;

                    priceDifference = totProductQtAmt - totProductRecAmt;
                }

                var company = _databaseContext.TenderBidSubmissions.Where(c => c.RegistrationNumber == tenderBid.RegistrationNumber).FirstOrDefault();

                decimal percentage = 0;

                if (priceDifference > 0)
                {
                    percentage = ((priceDifference / tenderBid.TotalQuotation) * 100);
        }


                if (percentage > 27 && percentage <= 30)
                {
                    eligibleSupplier.RegistrationNumber = company.RegistrationNumber;
                    eligibleSupplier.CompanyName = company.CompanyName;
                    eligibleSupplier.Tender = tender;
                    eligibleSupplier.TenderId = tender.TenderId;
                    eligibleSupplier.Score = 1;
                    eligibleSupplier.InflationRate = percentage;
                    eligibleSupplier.DateEvaluated = DateTime.Now;

                    tender.EligibleSuppliers.Add(eligibleSupplier);
                    //SaveToDatabase(eligibleSupplier);
                    //eligibleSuppliers.Add(eligibleSupplier);
                    //tender.EligibleSuppliers.Add(eligibleSupplier);
                    _databaseContext.SaveChanges();
                    Thread.Sleep(30);
                    //await Task.WhenAll(Task.Run(() => SaveToDatabase(eligibleSupplier)));

                }
                else if (percentage > 21 && percentage <= 24)
                {
                    eligibleSupplier.RegistrationNumber = company.RegistrationNumber;
                    eligibleSupplier.CompanyName = company.CompanyName;
                    eligibleSupplier.Tender = tender;
                    eligibleSupplier.TenderId = tender.TenderId;
                    eligibleSupplier.Score = 2;
                    eligibleSupplier.InflationRate = percentage;
                    eligibleSupplier.DateEvaluated = DateTime.Now;

                    tender.EligibleSuppliers.Add(eligibleSupplier);
                    //SaveToDatabase(eligibleSupplier);
                    //eligibleSuppliers.Add(eligibleSupplier);
                    //tender.EligibleSuppliers.Add(eligibleSupplier);
                    _databaseContext.SaveChanges();
                    Thread.Sleep(30);
                    //await Task.WhenAll(Task.Run(() => SaveToDatabase(eligibleSupplier)));
                }
                else if (percentage > 18 && percentage < 21)
                {
                    eligibleSupplier.RegistrationNumber = company.RegistrationNumber;
                    eligibleSupplier.CompanyName = company.CompanyName;
                    eligibleSupplier.Tender = tender;
                    eligibleSupplier.TenderId = tender.TenderId;
                    eligibleSupplier.Score = 3;
                    eligibleSupplier.InflationRate = percentage;
                    eligibleSupplier.DateEvaluated = DateTime.Now;

                    tender.EligibleSuppliers.Add(eligibleSupplier);
                    //SaveToDatabase(eligibleSupplier);
                    //eligibleSuppliers.Add(eligibleSupplier);
                    //tender.EligibleSuppliers.Add(eligibleSupplier);
                    _databaseContext.SaveChanges();
                    Thread.Sleep(30);
                    // await Task.WhenAll(Task.Run(() => SaveToDatabase(eligibleSupplier)));
                }
                else if (percentage > 15 && percentage <= 18)
                {
                    eligibleSupplier.RegistrationNumber = company.RegistrationNumber;
                    eligibleSupplier.CompanyName = company.CompanyName;
                    eligibleSupplier.Tender = tender;
                    eligibleSupplier.TenderId = tender.TenderId;
                    eligibleSupplier.Score = 4;
                    eligibleSupplier.InflationRate = percentage;
                    eligibleSupplier.DateEvaluated = DateTime.Now;

                    tender.EligibleSuppliers.Add(eligibleSupplier);
                    //SaveToDatabase(eligibleSupplier);
                    //eligibleSuppliers.Add(eligibleSupplier);
                    //tender.EligibleSuppliers.Add(eligibleSupplier);
                    _databaseContext.SaveChanges();
                    Thread.Sleep(30);
                    //await Task.WhenAll(Task.Run(() => SaveToDatabase(eligibleSupplier)));
                }
                else if (percentage > 10 && percentage <= 15)
                {
                    eligibleSupplier.RegistrationNumber = company.RegistrationNumber;
                    eligibleSupplier.CompanyName = company.CompanyName;
                    eligibleSupplier.Tender = tender;
                    eligibleSupplier.TenderId = tender.TenderId;
                    eligibleSupplier.Score = 5;
                    eligibleSupplier.InflationRate = percentage;
                    eligibleSupplier.DateEvaluated = DateTime.Now;


                    tender.EligibleSuppliers.Add(eligibleSupplier);
                    //SaveToDatabase(eligibleSupplier);
                    //eligibleSuppliers.Add(eligibleSupplier);
                    //tender.EligibleSuppliers.Add(eligibleSupplier);
                    _databaseContext.SaveChanges();
                    Thread.Sleep(30);
                    //await Task.WhenAll(Task.Run(() => SaveToDatabase(eligibleSupplier)));
                }
                else
                    continue;

            }

            //foreach(var supplier in eligibleSuppliers)
            //{
            //    tender.EligibleSuppliers.Add(supplier);
            //    _databaseContext.EligibleSuppliers.Add(supplier);
            //    _databaseContext.SaveChanges();
            //}

            //_databaseContext.SaveChanges();

           // await Task.WhenAll(Task.Run(() => SaveToDatabase(eligibleSupplier)));
            

        }

        public void SaveToDatabase(EligibleSupplier eligibleSupplier)
        {
            _databaseContext.EligibleSuppliers.Add(eligibleSupplier);
            _databaseContext.SaveChanges();            
        }

      
        public void CloseTender(TenderDto tenderDto)
        {
            var tender = _databaseContext.Tenders.Find(tenderDto.TenderId);

            tender.isClosed = true;
            _databaseContext.SaveChanges();

            EvaluationTenderBids(tender.TenderId);
        }

        public List<EligibleSupplier> GetTenderEligibleSuppliers(int tenderId)
        {
            var suppliers = _databaseContext.EligibleSuppliers.Where(t => t.TenderId == tenderId).ToList();
            
            return suppliers;
        }
    }
}
