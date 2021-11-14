using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class MailMessageResponse : BaseResponse<MailMessage>
    {
        public MailMessageResponse(string message) : base(message) { }

        public MailMessageResponse(MailMessage mailMessage) : base(mailMessage) { }

    }
}