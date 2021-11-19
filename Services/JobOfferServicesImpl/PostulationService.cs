using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.JobOfferRepositories;
using jobagapi.Domain.Services.Communication.JobOfferResponse;
using jobagapi.Domain.Services.JobOfferServices;


namespace jobagapi.Services.JobOfferServicesImpl
{
    public class PostulationService : IPostulationService
    {
         private readonly IPostulationRepository _postulationRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public PostulationService(IPostulationRepository postulation, IUnitOfWork unitOfWork)
        {
            _postulationRepository = postulation;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<Postulation>> ListAsync()
        {
            return await _postulationRepository.ListAsync();
        }
        //post
        public async Task<SavePostulationResponse> SaveAsync(Postulation postulation)
        {
            try
            {
                await _postulationRepository.AddAsync(postulation);
                await _unitOfWork.CompletedAsync();

                return new SavePostulationResponse(postulation);
            }
            catch (Exception e)
            {
                return new SavePostulationResponse($"An error occured while saving the postulation: ${e.Message}");
            }
        }
        //update
        public async Task<SavePostulationResponse> UpdateAsync(int id, Postulation postulation)
        {
            var existingPostulation = await _postulationRepository.FindByIdAsync(id);
            if (existingPostulation == null)
                return new SavePostulationResponse("Postulation not found.");

            existingPostulation.PostulantId = postulation.PostulantId;
            existingPostulation.JobOfferId = postulation.JobOfferId;
            existingPostulation.UrlVideo = postulation.UrlVideo;
            existingPostulation.Accepted = postulation.Accepted;
            
            try
            {
                _postulationRepository.Update(existingPostulation);
                await _unitOfWork.CompletedAsync();

                return new SavePostulationResponse(existingPostulation);
            }
            catch (Exception e)
            {
                return new SavePostulationResponse($"An error occured while updating the postulation: ${ e.Message }");
            }
        }
        //delete
        public async Task<PostulationResponse> DeleteAsync(int id)
        {
            var existingPostulation = await _postulationRepository.FindByIdAsync(id);
            if (existingPostulation == null) return new PostulationResponse("Postulation no found.");
            try
            {
                _postulationRepository.Remove(existingPostulation);
                await _unitOfWork.CompletedAsync();

                return new PostulationResponse(existingPostulation);
            }
            catch (Exception e)
            {
                return new PostulationResponse($"An error occured while delete the postulation: ${e.Message}");
            }
        }

        public async Task<IEnumerable<Postulation>> ListByPostulantIdAsync(int postulantId)
        {
            return await _postulationRepository.ListByPostulantIdAsync(postulantId);
        }

        public async Task<IEnumerable<Postulation>> ListByOfferIdAsync(int offerId)
        {
            return await _postulationRepository.ListByJobOfferIdAsync(offerId);
        }
    }
}