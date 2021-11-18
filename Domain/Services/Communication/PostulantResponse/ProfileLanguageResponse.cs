using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class ProfileLanguageResponse: BaseResponse<ProfileLanguage>
    {
        public ProfileLanguageResponse(ProfileLanguage resource) : base(resource)
        {
        }

        public ProfileLanguageResponse(string message) : base(message)
        {
        }
    }
}