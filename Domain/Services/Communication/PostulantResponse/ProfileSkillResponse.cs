using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class ProfileSkillResponse: BaseResponse<ProfileSkill>
    {
        public ProfileSkillResponse(ProfileSkill resource) : base(resource)
        {
        }

        public ProfileSkillResponse(string message) : base(message)
        {
        }
    }
}