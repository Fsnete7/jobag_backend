using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.JobOfferResponse;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace jobagapi.Services.JobOfferServicesImpl
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        //get

        public InterviewService(IInterviewRepository interview, IUnitOfWork unitOfWork)
        {
            _interviewRepository = interview;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Interview>> ListAsync()
        {
            return await _interviewRepository.ListAsync();
        }

        // post
        public async Task<SaveInterviewResponse> SaveAsync(Interview interview)
        {
            try
            {
                await _interviewRepository.AddAsync(interview);
                await _unitOfWork.CompletedAsync();

                return new SaveInterviewResponse(interview);
            }
            catch (Exception e)
            {
                return new SaveInterviewResponse($"An error occured while saving the interview: ${e.Message}");
            }
        }
        // UPDATE
        public async Task<SaveInterviewResponse> UpdateAsync(int id, Interview interview)
        {
            var existingInterview = await _interviewRepository.FindByIdAsync(id);
            if (existingInterview == null)
                return new SaveInterviewResponse("Interview not found.");

            existingInterview.PostulantId = interview.PostulantId;
            existingInterview.JobOfferId = interview.JobOfferId;
            existingInterview.Duration = interview.Duration;
            existingInterview.Link = interview.Link;
            existingInterview.Pending = interview.Pending;
            try
            {
                _interviewRepository.Update(existingInterview);
                await _unitOfWork.CompletedAsync();

                return new SaveInterviewResponse(existingInterview);
            }
            catch (Exception e)
            {
                return new SaveInterviewResponse($"An error occured while updating the interview: ${ e.Message }");
            }
        }

        // DELETE
        public async Task<InterviewResponse> DeleteAsync(int id)
        {
            var existingInterview = await _interviewRepository.FindByIdAsync(id);
            if (existingInterview == null) return new InterviewResponse("Interview no found.");
            try
            {
                _interviewRepository.Remove(existingInterview);
                await _unitOfWork.CompletedAsync();

                return new InterviewResponse(existingInterview);
            }
            catch (Exception e)
            {
                return new InterviewResponse($"An error occured while delete the interview: ${e.Message}");
            }
        }

        public async Task<IEnumerable<Interview>> ListByPostulantId(int interviewId)
        {
            return await _interviewRepository.ListByPostulantIdAsync(interviewId);
        }

        public async Task<IEnumerable<Interview>> ListByOfferIdAsync(int offerId)
        {
            return await _interviewRepository.ListByJobOfferIdAsync(offerId);
        }
    }
}