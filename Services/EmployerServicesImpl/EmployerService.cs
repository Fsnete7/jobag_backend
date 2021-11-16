

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.EmployerRepositories;
using jobagapi.Domain.Services.Communication.EmployerResponse;
using jobagapi.Domain.Services.EmployerServices;
using jobagapi.Persistence.Repositories.EmployerPersistence;

namespace jobagapi.Services.EmployerServicesImpl
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public EmployerService(IEmployerRepository employerRepository, IUnitOfWork unitOfWork)
        {
            _employerRepository = employerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employer>> ListAsync()
        {
            return await _employerRepository.ListAsync();
        }
        
        public async Task<EmployerResponse> SaveAsync(Employer employer)
        {
            try
            {
                await _employerRepository.AddAsync(employer);
                await _unitOfWork.CompleteAsync();

                return new EmployerResponse(employer);
            }
            catch (Exception e)
            {
                return new EmployerResponse($"An error ocurred while saving the job offer: {e.Message}");
            }
        }

        public async Task<EmployerResponse> UpdateAsync(int id, Employer employer)
        {
            var existingEmployer = await _employerRepository.FindByIdAsync(id);

            if (existingEmployer == null)
                return new EmployerResponse("Job Offer not found.");
//POR MODIFICAR
            existingEmployer.Id = employer.Id;
            try
            {
                _employerRepository.Update(existingEmployer);
                await _unitOfWork.CompleteAsync();

                return new EmployerResponse(existingEmployer);
            }
            catch (Exception e)
            {
                return new EmployerResponse($"An error ocurred while saving the job offer: {e.Message}");
            }
        }

        public async Task<EmployerResponse> DeletAsync(int id)
        {
            var existingEmployer = await _employerRepository.FindByIdAsync(id);
            
            if(existingEmployer == null)
                return new EmployerResponse("Job Offer not found.");

            try
            {
                _employerRepository.Delete(existingEmployer);
                await _unitOfWork.CompleteAsync();

                return new EmployerResponse(existingEmployer);
            }
            catch (Exception e)
            {
                return new EmployerResponse($"An error ocurred while deleting the job offer: {e.Message}");

            }
        }
    }
}