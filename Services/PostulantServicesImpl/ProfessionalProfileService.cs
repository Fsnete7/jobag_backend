using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Domain.Services.Communication.PostulantResponse;
using jobagapi.Domain.Services.PostulantServices;

namespace jobagapi.Services.PostulantServicesImpl
{
    public class ProfessionalProfileService : IProfessionalProfileService
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfessionalProfileService(IProfessionalRepository professionalRepository, IUnitOfWork unitOfWork)
        {
            _professionalRepository = professionalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfessionalProfileResponse> GetByIdAsync(int id)
        {
            var existingProfile = await _professionalRepository.FindById(id);

            if (existingProfile == null)
                return new ProfessionalProfileResponse("Profile not found");
            return new ProfessionalProfileResponse(existingProfile);
        }

        public async Task<ProfessionalProfileResponse> SaveAsync(ProfessionalProfile professionalProfile)
        {
            try
            {
                await _professionalRepository.AddAsync(professionalProfile);
                await _unitOfWork.CompletedAsync();
                return new ProfessionalProfileResponse(professionalProfile);
            }
            catch (Exception ex)
            {
                return new ProfessionalProfileResponse(
                    $"An error ocurred while saving the event profile: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProfessionalProfile>> ListAsync()
        {
            return await _professionalRepository.ListAsync();
        }

        public async Task<ProfessionalProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _professionalRepository.FindById(id);

            if (existingProfile == null)
                return new ProfessionalProfileResponse("Profile not found");

            try
            {
                _professionalRepository.Remove(existingProfile);
                await _unitOfWork.CompletedAsync();

                return new ProfessionalProfileResponse(existingProfile);
            }
            catch (Exception ex)
            {
                return new ProfessionalProfileResponse($"An error has ocurred while deleting profile: {ex.Message}");
            }
        }

        public async Task<ProfessionalProfileResponse> UpdateAsync(int id, ProfessionalProfile profile)
        {
            var existingProfile = await _professionalRepository.FindById(id);

            if (existingProfile == null)
                return new ProfessionalProfileResponse("Profile not found.");

 
            try
            {
                _professionalRepository.Update(existingProfile);
                await _unitOfWork.CompletedAsync();

                return new ProfessionalProfileResponse(existingProfile);
            }
            catch (Exception e)
            {
                return new ProfessionalProfileResponse($"An error ocurred while saving the Profile: {e.Message}");
            }
        }
    }
}
