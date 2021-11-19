using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class ProfessionalProfileResponse: BaseResponse<ProfessionalProfile>
    {
        public ProfessionalProfileResponse(string message) : base(message) { }

        public ProfessionalProfileResponse(ProfessionalProfile professionalProfile) : base(professionalProfile) { }
    }
}