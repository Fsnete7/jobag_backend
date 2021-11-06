using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.JobOffer;

namespace jobagapi.Services
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

        public async Task<SaveMailMessageResponse> SaveAsync(MailMessage mailMessage)
        {
            try
            {
                await _mailMessageRepository.AddAsync(mailMessage);
                await _unitOfWork.CompleteAsync();

                return new SaveMailMessageResponse(mailMessage);
            }
            catch (Exception e)
            {
                return new SaveMailMessageResponse($"An error ocurred while saving the mail message: {e.Message}");
            }
        }

        public async Task<MailMessageResponse> DeletAsync(int id)
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