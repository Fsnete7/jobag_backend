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
    public class ProfileLanguageService: IProfileLanguageService
    {
        private readonly IProfileLanguageRepository _profileLanguageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileLanguageService(IProfileLanguageRepository profileLanguageRepository, IUnitOfWork unitOfWork)
        {
            _profileLanguageRepository = profileLanguageRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<ProfileLanguage>> ListAsync()
        {
            return await _profileLanguageRepository.ListAsync();
        }

        public async Task<IEnumerable<ProfileLanguage>> ListByProfileIdAsync(int profileId)
        {
            return await _profileLanguageRepository.ListByProfileIdAsync(profileId);
        }

        public async Task<IEnumerable<ProfileLanguage>> ListByLanguageIdAsync(int languageId)
        {
            return await _profileLanguageRepository.ListByLanguageIdAsync(languageId);
        }

        public async Task<ProfileLanguageResponse> AssignProfileLanguageAsync(int profileId, int languageId)
        {
            try
            {
                await _profileLanguageRepository.AssignProfileLanguage(profileId, languageId);
                await _unitOfWork.CompletedAsync();
                ProfileLanguage profileLanguage = await _profileLanguageRepository.FindByProfileIdAndSkillId(profileId,languageId);
                return new ProfileLanguageResponse(profileLanguage);

            }
            catch (Exception ex)
            {
                return new ProfileLanguageResponse($"An error ocurred while assigning Language to Profile: {ex.Message}");
            }
        }

        public async Task<ProfileLanguageResponse> UnassignProfileLanguageAsync(int profileId, int languageId)
        {
            try
            {
                ProfileLanguage profileLanguage = await _profileLanguageRepository.FindByProfileIdAndSkillId(profileId,languageId);

                _profileLanguageRepository.Remove(profileLanguage);
                await _unitOfWork.CompletedAsync();

                return new ProfileLanguageResponse(profileLanguage);

            }
            catch (Exception ex)
            {
                return new ProfileLanguageResponse($"An error ocurred while unassigning Language from Profile: {ex.Message}");
            }
        }
    }
}