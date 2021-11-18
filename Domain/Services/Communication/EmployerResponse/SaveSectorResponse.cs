using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Services.Communication.EmployerResponse
{
    public class SaveSectorResponse : BaseResponse<Sector>
    {
        public SaveSectorResponse(Sector resource) : base(resource) { }
        public SaveSectorResponse(string message = null) : base(message) { }

    }
}