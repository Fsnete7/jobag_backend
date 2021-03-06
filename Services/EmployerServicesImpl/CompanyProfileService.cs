using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.EmployerRepositories;
using jobagapi.Domain.Services.Communication.CompanyProfileResponse;
using jobagapi.Domain.Services.Communication.EmployerResponse;
using jobagapi.Domain.Services.EmployerServices;

namespace jobagapi.Services.EmployerServicesImpl
{
    public class CompanyProfileService : ICompanyProfileService
    {
         private readonly ICompanyProfileRepository _companyProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CompanyProfileService(ICompanyProfileRepository companyProfileRepository, IUnitOfWork unitOfWork)
        {
            _companyProfileRepository = companyProfileRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CompanyProfile>> ListAsync()
        {
            return await _companyProfileRepository.ListAsync();
        }
        
        public async Task<SaveCompanyProfileResponse> SaveAsync(CompanyProfile companyProfile)
        {
            try
            {
                await _companyProfileRepository.AddAsync(companyProfile);
                await _unitOfWork.CompletedAsync();

                return new SaveCompanyProfileResponse(companyProfile);
            }
            catch (Exception e)
            {
                return new SaveCompanyProfileResponse($"An error ocurred while saving the company profile: {e.Message}");
            }
        }

        public async Task<SaveCompanyProfileResponse> UpdateAsync(int id, CompanyProfile companyProfile)
        {
            var existingCompanyProfile = await _companyProfileRepository.FindByIdAsync(id);

            if (existingCompanyProfile == null)
                return new SaveCompanyProfileResponse("company profile not found.");

           
            existingCompanyProfile.City= companyProfile.City;
            existingCompanyProfile.Country= companyProfile.Country;
            existingCompanyProfile.Direction= companyProfile.Direction;
            existingCompanyProfile.District= companyProfile.District;
            
            try
            {
                _companyProfileRepository.Update(existingCompanyProfile);
                await _unitOfWork.CompletedAsync();

                return new SaveCompanyProfileResponse(existingCompanyProfile);
            }
            catch (Exception e)
            {
                return new SaveCompanyProfileResponse($"An error ocurred while saving the company profile: {e.Message}");
            }
        }

        public async Task<CompanyProfileResponse> DeleteAsync(int id)
        {
            var existingCompanyProfile= await _companyProfileRepository.FindByIdAsync(id);
            
            if(existingCompanyProfile == null)
                return new CompanyProfileResponse("company profile not found.");

            try
            {
                _companyProfileRepository.Delete(existingCompanyProfile);
                await _unitOfWork.CompletedAsync();

                return new CompanyProfileResponse(existingCompanyProfile);
            }
            catch (Exception e)
            {
                return new CompanyProfileResponse($"An error ocurred while deleting the company profile: {e.Message}");

            }
        }
    }
}