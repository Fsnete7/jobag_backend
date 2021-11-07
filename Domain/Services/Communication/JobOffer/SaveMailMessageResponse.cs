using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class SaveMailMessageResponse : BaseResponse
    {
        public MailMessage MailMessage { get; private set; }
       
        
        public SaveMailMessageResponse(bool succes, string message, MailMessage mailMessage) : base(succes, message)
        {
            MailMessage = mailMessage;
        }
        public SaveMailMessageResponse(MailMessage mailMessage) : this(true, string.Empty, mailMessage){}
        
        public SaveMailMessageResponse(string message) : this(false, message, null){}

    }
}