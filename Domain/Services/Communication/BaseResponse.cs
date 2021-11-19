using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; set; }

        public BaseResponse(T resource)
        {
            Success = true;
            Resource = resource;
        }
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
        
    }
}