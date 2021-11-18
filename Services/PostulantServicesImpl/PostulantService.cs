using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.PostulantResponse;
using jobagapi.Domain.Services.PostulantServices;

namespace jobagapi.Services.PostulantServicesImpl
{
    public class PostulantService: IPostulantService
    {
        private readonly IPostulantRepository _postulantRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public PostulantService(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            _postulantRepository = postulantRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<PostulantResponse> GetByIdAsync(int id)
        {
            var existingPostulant = await _postulantRepository.FindById(id);

            if(existingPostulant == null)
                return new PostulantResponse("Postulant not found");
            return new PostulantResponse(existingPostulant);
        }

        public async Task<PostulantResponse> SaveAsync(Postulant postulant)
        {
            try
            {
                await _postulantRepository.AddAsync(postulant);
                await _unitOfWork.CompletedAsync();
                return new PostulantResponse(postulant);
            }
            catch (Exception ex)
            {
                return new PostulantResponse($"An error ocurred while saving the event postulant: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Postulant>> ListAsync()
        {
            return await _postulantRepository.ListAsync();
        }

        public async Task<PostulantResponse> DeleteAsync(int id)
        {
            var existingPerformer = await _postulantRepository.FindById(id);

            if (existingPerformer == null)
                return new PostulantResponse("Postulant not found");

            try
            {
                _postulantRepository.Remove(existingPerformer);
                await _unitOfWork.CompletedAsync();

                return new PostulantResponse(existingPerformer);
            }
            catch (Exception ex)
            {
                return new PostulantResponse($"An error has ocurred while deleting postulant: {ex.Message}");
            }
        }
        
        public async Task<PostulantResponse> UpdateAsync(int id, Postulant postulant)
        {
            var existingPostulant = await _postulantRepository.FindById(id);

            if (existingPostulant == null)
                return new PostulantResponse("Postulant not found.");

            existingPostulant.FirstName = postulant.FirstName;
            try
            {
                _postulantRepository.Update(existingPostulant);
                await _unitOfWork.CompletedAsync();

                return new PostulantResponse(existingPostulant);
            }
            catch (Exception e)
            {
                return new PostulantResponse($"An error ocurred while saving the postulant: {e.Message}");
            }
        }
    }
}