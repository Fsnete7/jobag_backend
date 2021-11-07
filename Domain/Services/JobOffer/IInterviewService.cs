﻿using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services.Communication.JobOffer;

namespace jobagapi.Domain.Services
{
    public interface IInterviewService
    {
        Task<IEnumerable<Interview>> ListAsync();

        Task<SaveInterviewResponse> SaveAsync(Interview interview);

        Task<SaveInterviewResponse> UpdateAsync(int id, Interview interview);

        Task<InterviewResponse> DeletAsync(int id);  
    }
}