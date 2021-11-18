using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.EmployerRepositories;
using jobagapi.Domain.Services.Communication.EmployerResponse;
using jobagapi.Domain.Services.EmployerServices;

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
        
        public async Task<SaveEmployerResponse> SaveAsync(Employer employer)
        {
            try
            {
                await _employerRepository.AddAsync(employer);
                await _unitOfWork.CompletedAsync();

                return new SaveEmployerResponse(employer);
            }
            catch (Exception e)
            {
                return new SaveEmployerResponse($"An error ocurred while saving the employer: {e.Message}");
            }
        }

        public async Task<SaveEmployerResponse> UpdateAsync(int id, Employer employer)
        {
            var existingEmployer = await _employerRepository.FindByIdAsync(id);

            if (existingEmployer == null)
                return new SaveEmployerResponse("employer not found.");
            //
            existingEmployer.Position = employer.Position;
            
            try
            {
                _employerRepository.Update(existingEmployer);
                await _unitOfWork.CompletedAsync();

                return new SaveEmployerResponse(existingEmployer);
            }
            catch (Exception e)
            {
                return new SaveEmployerResponse($"An error ocurred while saving the employer: {e.Message}");
            }
        }

        public async Task<EmployerResponse> DeleteAsync(int id)
        {
            var existingEmployer = await _employerRepository.FindByIdAsync(id);
            
            if(existingEmployer == null)
                return new EmployerResponse("employer not found.");

            try
            {
                _employerRepository.Delete(existingEmployer);
                await _unitOfWork.CompletedAsync();

                return new EmployerResponse(existingEmployer);
            }
            catch (Exception e)
            {
                return new EmployerResponse($"An error ocurred while deleting the employer: {e.Message}");

            }
        }
    }
}