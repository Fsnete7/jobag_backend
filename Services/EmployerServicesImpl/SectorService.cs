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
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public SectorService(ISectorRepository sectorRepository, IUnitOfWork unitOfWork)
        {
            _sectorRepository = sectorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Sector>> ListAsync()
        {
            return await _sectorRepository.ListAsync();
        }

        public async Task<SaveSectorResponse> SaveAsync(Sector sector)
        {
            try
            {
                await _sectorRepository.AddAsync(sector);
                await _unitOfWork.CompletedAsync();

                return new SaveSectorResponse(sector);
            }
            catch (Exception e)
            {
                return new SaveSectorResponse($"An error ocurred while saving the sector: {e.Message}");
            }
        }

        public async Task<SaveSectorResponse> UpdateAsync(int id, Sector jobOffer)
        {
            var existingSector = await _sectorRepository.FindByIdAsync(id);

            if (existingSector == null)
                return new SaveSectorResponse("Sector not found.");

            existingSector.Name = jobOffer.Name;
            existingSector.Description = jobOffer.Description;
         
            try
            {
                _sectorRepository.Update(existingSector);
                await _unitOfWork.CompletedAsync();

                return new SaveSectorResponse(existingSector);
            }
            catch (Exception e)
            {
                return new SaveSectorResponse($"An error occurred while saving the Sector: {e.Message}");
            }
        }
       
        public async Task<SectorResponse> DeleteAsync(int id)
        {
            var existingSector = await _sectorRepository.FindByIdAsync(id);
            
            if(existingSector == null)
                return new SectorResponse("Sector not found.");

            try
            {
                _sectorRepository.Delete(existingSector);
                await _unitOfWork.CompletedAsync();

                return new SectorResponse(existingSector);
            }
            catch (Exception e)
            {
                return new SectorResponse($"An error ocurred while deleting the sector: {e.Message}");

            }
        }
    }
}