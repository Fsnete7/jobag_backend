using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.SubscriptionRepositories;
using jobagapi.Domain.Services.Communication.SubscriptionResponse;
using jobagapi.Domain.Services.SubscriptionServices;

namespace jobagapi.Services.SubscriptionServicesImpl
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
         private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public SubscriptionPlanService(ISubscriptionPlanRepository subscriptionPlan, IUnitOfWork unitOfWork)
        {
            _subscriptionPlanRepository = subscriptionPlan;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<SubscriptionPlan>> ListAsync()
        {
            return await _subscriptionPlanRepository.ListAsync();
        }
        //post
        public async Task<SaveSubscriptionPlanResponse> SaveAsync(SubscriptionPlan subscriptionPlan)
        {
            try
            {
                await _subscriptionPlanRepository.AddAsync(subscriptionPlan);
                await _unitOfWork.CompletedAsync();

                return new SaveSubscriptionPlanResponse(subscriptionPlan);
            }
            catch (Exception e)
            {
                return new SaveSubscriptionPlanResponse($"An error occured while saving the subscriptionPlan: ${e.Message}");
            }
        }
        //update
        public async Task<SaveSubscriptionPlanResponse> UpdateAsync(int id, SubscriptionPlan subscriptionPlan)
        {
            var existingSubscriptionPlan = await _subscriptionPlanRepository.FindByIdAsync(id);
            if (existingSubscriptionPlan == null)
                return new SaveSubscriptionPlanResponse("SubscriptionPlan not found.");
            
            existingSubscriptionPlan.Description = subscriptionPlan.Description;  
            existingSubscriptionPlan.LimitVideoCreation = subscriptionPlan.LimitVideoCreation;
            existingSubscriptionPlan.LimitPostulation = subscriptionPlan.LimitPostulation;
            existingSubscriptionPlan.PreDesignTemplates = subscriptionPlan.PreDesignTemplates;
            existingSubscriptionPlan.Duration = subscriptionPlan.Duration;
            existingSubscriptionPlan.LimitModification = subscriptionPlan.LimitModification;
            existingSubscriptionPlan.Assistance = subscriptionPlan.Assistance;
            
            try
            {
                _subscriptionPlanRepository.Update(existingSubscriptionPlan);
                await _unitOfWork.CompletedAsync();

                return new SaveSubscriptionPlanResponse(existingSubscriptionPlan);
            }
            catch (Exception e)
            {
                return new SaveSubscriptionPlanResponse($"An error occured while updating the subscriptionPlan: ${ e.Message }");
            }
        }
        //delete
        public async Task<SubscriptionPlanResponse> DeleteAsync(int id)
        {
            var existingSubscriptionPlan = await _subscriptionPlanRepository.FindByIdAsync(id);
            if (existingSubscriptionPlan == null) return new SubscriptionPlanResponse("SubscriptionPlan no found.");
            try
            {
                _subscriptionPlanRepository.Remove(existingSubscriptionPlan);
                await _unitOfWork.CompletedAsync();

                return new SubscriptionPlanResponse(existingSubscriptionPlan);
            }
            catch (Exception e)
            {
                return new SubscriptionPlanResponse($"An error occured while delete the subscriptionPlan: ${e.Message}");
            }
        }
    }
}