namespace jobagapi.Domain.Services.Communication
{
    public class BaseResponse
    {
        public BaseResponse(bool succes, string message)
        {
            Succes = succes;
            Message = message;
        }

        public  bool Succes { get; protected set; }
        public string Message { get; protected set; }
    }
}