using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Domain.Services.Communication.PostulantResponse;
using jobagapi.Domain.Services.PostulantServices;

namespace jobagapi.Services.PostulantServicesImpl
{
    public class LanguageService: ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfileLanguageRepository _profileLanguageRepository;
        
        public LanguageService(ILanguageRepository languageRepository, IUnitOfWork unitOfWork, IProfileLanguageRepository profileLanguageRepository)
        {
            _languageRepository = languageRepository;
            _unitOfWork = unitOfWork;
            _profileLanguageRepository = profileLanguageRepository;
        }
        
        public async Task<LanguageResponse> GetByIdAsync(int id)
        {
            var existingLanguage = await _languageRepository.FindById(id);

            if(existingLanguage == null)
                return new LanguageResponse("Language not found");
            return new LanguageResponse(existingLanguage);
        }

        public async Task<IEnumerable<Language>> ListByProfileIdAsync(int profileId)
        {
            var profileLanguages = await _profileLanguageRepository.ListByProfileIdAsync(profileId);
            var languages = profileLanguages.Select(pt => pt.Language).ToList();
            return languages;
        }

        public async Task<LanguageResponse> SaveAsync(Language language)
        {
            try
            {
                await _languageRepository.AddAsync(language);
                await _unitOfWork.CompletedAsync();
                return new LanguageResponse(language);
            }
            catch (Exception ex)
            {
                return new LanguageResponse($"An error ocurred while saving the event language: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Language>> ListAsync()
        {
            return await _languageRepository.ListAsync();
        }

        public async Task<LanguageResponse> DeleteAsync(int id)
        {
            var existingLanguage = await _languageRepository.FindById(id);

            if (existingLanguage == null)
                return new LanguageResponse("Language not found");

            try
            {
                _languageRepository.Remove(existingLanguage);
                await _unitOfWork.CompletedAsync();

                return new LanguageResponse(existingLanguage);
            }
            catch (Exception ex)
            {
                return new LanguageResponse($"An error has ocurred while deleting language: {ex.Message}");
            }
        }

        public async Task<LanguageResponse> UpdateAsync(int id, Language language)
        {
            var existingLanguage = await _languageRepository.FindById(id);

            if (existingLanguage == null)
                return new LanguageResponse("Language not found.");

            existingLanguage.Level = language.Level;
            existingLanguage.Name = language.Name;
            
            try
            {
                _languageRepository.Update(existingLanguage);
                await _unitOfWork.CompletedAsync();

                return new LanguageResponse(existingLanguage);
            }
            catch (Exception e)
            {
                return new LanguageResponse($"An error ocurred while saving the Degree: {e.Message}");
            }
        }
    }
}