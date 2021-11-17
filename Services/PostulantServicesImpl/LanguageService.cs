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
    public class LanguageService: ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public LanguageService(ILanguageRepository languageRepository, IUnitOfWork unitOfWork)
        {
            _languageRepository = languageRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<LanguageResponse> GetByIdAsync(int id)
        {
            var existingLanguage = await _languageRepository.FindById(id);

            if(existingLanguage == null)
                return new LanguageResponse("Language not found");
            return new LanguageResponse(existingLanguage);
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
    }
}