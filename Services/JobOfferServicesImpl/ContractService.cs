using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.JobOfferResponse;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Services.JobOfferServicesImpl
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContractService(IContractRepository contractRepository, IUnitOfWork unitOfWork)
        {
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ContractResponse> GetByIdAsync(int id)
        {
            var existingContract = await _contractRepository.FindByIdAsync(id);

            if (existingContract == null)
                return new ContractResponse("Contract not found");
            return new ContractResponse(existingContract);
        }
        
        
        public async Task<SaveContractResponse> SaveAsync(Contract contract)
        {
            try
            {
                await _contractRepository.AddAsync(contract);
                await _unitOfWork.CompletedAsync();
                return new SaveContractResponse(contract);
            }
            catch (Exception ex)
            {
                return new SaveContractResponse(
                    $"An error occurred while saving the event contract: {ex.Message}");
            }
        }
        
        
        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await _contractRepository.ListAsync();
        }

        public async Task<ContractResponse> DeleteAsync(int id)
        {
            var existingContract = await _contractRepository.FindByIdAsync(id);

            if (existingContract == null)
                return new ContractResponse("Contract not found");

            try
            {
                _contractRepository.Remove(existingContract);
                await _unitOfWork.CompletedAsync();

                return new ContractResponse(existingContract);
            }
            catch (Exception ex)
            {
                return new ContractResponse($"An error has occurred while deleting Contract: {ex.Message}");
            }
        }
        // UPDATE
        public async Task<SaveContractResponse> UpdateAsync(int id, Contract contract)
        {
            var existingContract = await _contractRepository.FindByIdAsync(id);
            if (existingContract == null)
                return new SaveContractResponse("Contract not found.");
            
            existingContract.Description = contract.Description;
            existingContract.Confirmation = contract.Confirmation;
            
            try
            {
                _contractRepository.Update(existingContract);
                await _unitOfWork.CompletedAsync();

                return new SaveContractResponse(existingContract);
            }
            catch (Exception e)
            {
                return new SaveContractResponse($"An error occurred while saving the Contract: {e.Message}");
            }
        }

    
    }
}