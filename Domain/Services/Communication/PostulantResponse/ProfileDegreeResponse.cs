using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class ProfileDegreeResponse: BaseResponse<ProfileDegree>
    {
        public ProfileDegreeResponse(ProfileDegree resource) : base(resource)
        {
        }

        public ProfileDegreeResponse(string message) : base(message)
        {
        }
    }
}