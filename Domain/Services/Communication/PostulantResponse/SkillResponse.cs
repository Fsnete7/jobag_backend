using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class SkillResponse: BaseResponse<Skill>
    {
        public SkillResponse(string message) : base(message) { }

        public SkillResponse(Skill skill) : base(skill) { }
    }
}