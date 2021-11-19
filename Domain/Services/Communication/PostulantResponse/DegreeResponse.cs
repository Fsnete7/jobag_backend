using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class DegreeResponse: BaseResponse<Degree>
    {
        public DegreeResponse(string message) : base(message) { }

        public DegreeResponse(Degree degree) : base(degree) { }
        
    }
}