using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class LanguageResponse: BaseResponse<Language>
    {
        public LanguageResponse(string message) : base(message) { }

        public LanguageResponse(Language language) : base(language) { }
    }
}