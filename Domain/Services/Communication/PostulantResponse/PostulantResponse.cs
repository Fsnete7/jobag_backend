using jobagapi.Domain.Models.PostulantSystem;
 

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class PostulantResponse : BaseResponse<Postulant>
    {
        public PostulantResponse(string message) : base(message) { }

        public PostulantResponse(Postulant postulant) : base(postulant) { }
        
    }
}