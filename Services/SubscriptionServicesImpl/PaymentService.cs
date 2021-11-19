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
    public class PaymentService : IPaymentService
    {
         private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public PaymentService(IPaymentRepository payment, IUnitOfWork unitOfWork)
        {
            _paymentRepository = payment;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _paymentRepository.ListAsync();
        }
        //post
        public async Task<SavePaymentResponse> SaveAsync(Payment payment)
        {
            try
            {
                await _paymentRepository.AddAsync(payment);
                await _unitOfWork.CompletedAsync();

                return new SavePaymentResponse(payment);
            }
            catch (Exception e)
            {
                return new SavePaymentResponse($"An error occured while saving the payment: ${e.Message}");
            }
        }
        //update
        public async Task<SavePaymentResponse> UpdateAsync(int id, Payment payment)
        {
            var existingPayment = await _paymentRepository.FindByIdAsync(id);
            if (existingPayment == null)
                return new SavePaymentResponse("Payment not found.");
            
            existingPayment.CarNumber = payment.CarNumber;  
            existingPayment.AmountTotal = payment.AmountTotal;
            existingPayment.Details = payment.Details;
            try
            {
                _paymentRepository.Update(existingPayment);
                await _unitOfWork.CompletedAsync();

                return new SavePaymentResponse(existingPayment);
            }
            catch (Exception e)
            {
                return new SavePaymentResponse($"An error occured while updating the payment: ${ e.Message }");
            }
        }
        //delete
        public async Task<PaymentResponse> DeleteAsync(int id)
        {
            var existingPayment = await _paymentRepository.FindByIdAsync(id);
            if (existingPayment == null) return new PaymentResponse("Payment no found.");
            try
            {
                _paymentRepository.Remove(existingPayment);
                await _unitOfWork.CompletedAsync();

                return new PaymentResponse(existingPayment);
            }
            catch (Exception e)
            {
                return new PaymentResponse($"An error occured while delete the payment: ${e.Message}");
            }
        }
    }
}