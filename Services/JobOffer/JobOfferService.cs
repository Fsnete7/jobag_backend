using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.JobOffer;
using jobagapi.Resources;

namespace jobagapi.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public JobOfferService(IJobOfferRepository jobOfferRepository, IUnitOfWork unitOfWork)
        {
            _jobOfferRepository = jobOfferRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<JobOffer>> ListAsync()
        {
            return await _jobOfferRepository.ListAsync();
        }

        public async Task<SaveJobOfferResponse> SaveAsync(JobOffer jobOffer)
        {
            try
            {
                await _jobOfferRepository.AddAsync(jobOffer);
                await _unitOfWork.CompleteAsync();

                return new SaveJobOfferResponse(jobOffer);
            }
            catch (Exception e)
            {
                return new SaveJobOfferResponse($"An error ocurred while saving the job offer: {e.Message}");
            }
        }

        public async Task<SaveJobOfferResponse> UpdateAsync(int id, JobOffer jobOffer)
        {
            var existingJobOffer = await _jobOfferRepository.FindByIdAsync(id);

            if (existingJobOffer == null)
                return new SaveJobOfferResponse("Job Offer not found.");

            existingJobOffer.Name = jobOffer.Name;
            try
            {
                _jobOfferRepository.update(existingJobOffer);
                await _unitOfWork.CompleteAsync();

                return new SaveJobOfferResponse(existingJobOffer);
            }
            catch (Exception e)
            {
                return new SaveJobOfferResponse($"An error ocurred while saving the job offer: {e.Message}");
            }
        }

        public async Task<JobOfferResponse> DeletAsync(int id)
        {
            var existingJobOffer = await _jobOfferRepository.FindByIdAsync(id);
            
            if(existingJobOffer == null)
                return new JobOfferResponse("Job Offer not found.");

            try
            {
                _jobOfferRepository.Delete(existingJobOffer);
                await _unitOfWork.CompleteAsync();

                return new JobOfferResponse(existingJobOffer);
            }
            catch (Exception e)
            {
                return new JobOfferResponse($"An error ocurred while deleting the job offer: {e.Message}");

            }
        }
    }
}