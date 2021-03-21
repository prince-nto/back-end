using ControllerApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderSystem.Models;

namespace TenderSystem.Services
{
    public interface ITenderBidService
    {
        TenderBidSubmission AddTenderBidSubmission(TenderBidSubmissionDto tenderBidSubmissionDto);
        TenderBidSubmission UpdateTenderBidSubmission(TenderBidSubmissionDto tenderBidSubmissionDto);
    }
}
