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
    public class ProfileDegreeService: IProfileDegreeService
    {
        private readonly IProfileDegreeRepository _profileDegreeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileDegreeService(IProfileDegreeRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _profileDegreeRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<ProfileDegree>> ListAsync()
        {
            return await _profileDegreeRepository.ListAsync();
        }

        public async Task<IEnumerable<ProfileDegree>> ListByProfileIdAsync(int profileId)
        {
            return await _profileDegreeRepository.ListByProfileIdAsync(profileId);
        }

        public async Task<IEnumerable<ProfileDegree>> ListByDegreeIdAsync(int degreeId)
        {
            return await _profileDegreeRepository.ListByDegreeIdAsync(degreeId);
        }

        public async Task<ProfileDegreeResponse> AssignProfileDegreeAsync(int profileId, int degreeId)
        {
            try
            {
                await _profileDegreeRepository.AssignProfileDegree(profileId, degreeId);
                await _unitOfWork.CompletedAsync();
                ProfileDegree profileDegree = await _profileDegreeRepository.FindByProfileIdAndDegreeId(profileId, degreeId);
                return new ProfileDegreeResponse(profileDegree);

            }
            catch (Exception ex)
            {
                return new ProfileDegreeResponse($"An error ocurred while assigning Degree to Profile: {ex.Message}");
            }
        }

        public async Task<ProfileDegreeResponse> UnassignProfileDegreeAsync(int profileId, int degreeId)
        {
            try
            {
                ProfileDegree profileDegree = await _profileDegreeRepository.FindByProfileIdAndDegreeId(profileId, degreeId);

                _profileDegreeRepository.Remove(profileDegree);
                await _unitOfWork.CompletedAsync();

                return new ProfileDegreeResponse(profileDegree);

            }
            catch (Exception ex)
            {
                return new ProfileDegreeResponse($"An error ocurred while unassigning Degree from Profile: {ex.Message}");
            }
        }
    }
}