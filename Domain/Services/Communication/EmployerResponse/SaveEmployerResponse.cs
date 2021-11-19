using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Services.Communication.EmployerResponse
{
    public class SaveEmployerResponse : BaseResponse<Employer>
    {
        public SaveEmployerResponse(Employer resource) : base(resource) { }
        public SaveEmployerResponse(string message = null) : base(message) { }

    }
}