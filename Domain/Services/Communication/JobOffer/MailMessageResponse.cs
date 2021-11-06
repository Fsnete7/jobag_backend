using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class MailMessageResponse : BaseResponse
    {
        public MailMessage MailMessage { get; set; }

        public MailMessageResponse(bool succes, string message, MailMessage mailMessage) : base(succes, message)
        {
            MailMessage = mailMessage;
        }
        
        public MailMessageResponse(MailMessage mailMessage) : this(true, string.Empty, mailMessage) {}
        
        public MailMessageResponse(string message) : this(false, message, null) {}

    }
}