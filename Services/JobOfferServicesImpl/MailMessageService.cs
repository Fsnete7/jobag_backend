using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.JobOfferRepositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.JobOfferResponse;
using jobagapi.Domain.Services.JobOfferServices;

namespace jobagapi.Services.JobOfferServicesImpl
{
    public class MailMessageService : IMailiMessageService
    {
        private readonly IMailMessageRepository _mailMessageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MailMessageService(IMailMessageRepository mailMessageRepository, IUnitOfWork unitOfWork)
        {
            _mailMessageRepository = mailMessageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MailMessage>> ListAsync()
        {
            return await _mailMessageRepository.ListAsync();
        }

        public async Task<MailMessageResponse> SaveAsync(MailMessage mailMessage)
        {
            try
            {
                await _mailMessageRepository.AddAsync(mailMessage);
                await _unitOfWork.CompleteAsync();

                return new MailMessageResponse(mailMessage);
            }
            catch (Exception e)
            {
                return new MailMessageResponse($"An error ocurred while saving the mail message: {e.Message}");
            }
        }

        public async Task<MailMessageResponse> DeleteAsync(int id)
        {
            var existingMailMessage = await _mailMessageRepository.FindByIdAsync(id);

            if (existingMailMessage == null)
                return new MailMessageResponse("Mail message not found");

            try
            {
                _mailMessageRepository.Delete(existingMailMessage);
                await _unitOfWork.CompleteAsync();

                return new MailMessageResponse(existingMailMessage);
            }
            catch (Exception e)
            {
                return new MailMessageResponse($"An error ocurred while saving the mail message: {e.Message}");
            }
        }

    }
}