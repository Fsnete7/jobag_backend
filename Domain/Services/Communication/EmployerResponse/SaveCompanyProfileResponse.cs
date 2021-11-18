using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Services.Communication.EmployerResponse
{
    public class SaveCompanyProfileResponse : BaseResponse<CompanyProfile>
    {
        public SaveCompanyProfileResponse(CompanyProfile resource) : base(resource) { }
        public SaveCompanyProfileResponse(string message = null) : base(message) { }

    }
}