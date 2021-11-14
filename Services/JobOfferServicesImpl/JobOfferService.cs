using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.JobOfferRepositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.JobOfferResponse;
using jobagapi.Domain.Services.JobOfferServices;

namespace jobagapi.Services.JobOfferServicesImpl
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

        public async Task<JobOfferResponse> SaveAsync(JobOffer jobOffer)
        {
            try
            {
                await _jobOfferRepository.AddAsync(jobOffer);
                await _unitOfWork.CompleteAsync();

                return new JobOfferResponse(jobOffer);
            }
            catch (Exception e)
            {
                return new JobOfferResponse($"An error ocurred while saving the job offer: {e.Message}");
            }
        }

        public async Task<JobOfferResponse> UpdateAsync(int id, JobOffer jobOffer)
        {
            var existingJobOffer = await _jobOfferRepository.FindByIdAsync(id);

            if (existingJobOffer == null)
                return new JobOfferResponse("Job Offer not found.");

            existingJobOffer.Name = jobOffer.Name;
            try
            {
                _jobOfferRepository.update(existingJobOffer);
                await _unitOfWork.CompleteAsync();

                return new JobOfferResponse(existingJobOffer);
            }
            catch (Exception e)
            {
                return new JobOfferResponse($"An error ocurred while saving the job offer: {e.Message}");
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