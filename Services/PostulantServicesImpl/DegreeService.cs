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
    public class DegreeService: IDegreeService
    {
        private readonly IDegreeRepository _degreeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DegreeService(IDegreeRepository degreeRepository, IUnitOfWork unitOfWork)
        {
            _degreeRepository = degreeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DegreeResponse> GetByIdAsync(int id)
        {
            var existingDegree = await _degreeRepository.FindById(id);

            if(existingDegree == null)
                return new DegreeResponse("Degree not found");
            return new DegreeResponse(existingDegree);
        }

        public async Task<DegreeResponse> SaveAsync(Degree degree)
        {
            try
            {
                await _degreeRepository.AddAsync(degree);
                await _unitOfWork.CompletedAsync();
                return new DegreeResponse(degree);
            }
            catch (Exception ex)
            {
                return new DegreeResponse($"An error ocurred while saving the event degree: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Degree>> ListAsync()
        {
            return await _degreeRepository.ListAsync();
        }

        public async Task<DegreeResponse> DeleteAsync(int id)
        {
            var existingDegree = await _degreeRepository.FindById(id);

            if (existingDegree == null)
                return new DegreeResponse("Degree not found");

            try
            {
                _degreeRepository.Remove(existingDegree);
                await _unitOfWork.CompletedAsync();

                return new DegreeResponse(existingDegree);
            }
            catch (Exception ex)
            {
                return new DegreeResponse($"An error has ocurred while deleting Degree: {ex.Message}");
            }
        }
    }
}