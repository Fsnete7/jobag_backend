
namespace jobagapi.Domain.Services.Communication.CompanyProfileResponse
{
    public class CompanyProfileResponse : BaseResponse<Models.EmployerSystem.CompanyProfile>
    {
        public CompanyProfileResponse(string message) : base(message) { }

        public CompanyProfileResponse(Models.EmployerSystem.CompanyProfile companyProfile) : base(companyProfile) { }

    }
}