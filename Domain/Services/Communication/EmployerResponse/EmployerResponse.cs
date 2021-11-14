namespace jobagapi.Domain.Services.Communication.EmployerResponse
{
    public class EmployerResponse: BaseResponse<Models.EmployerSystem.Employer>
    {
        public EmployerResponse(string message) : base(message) { }

        public EmployerResponse(Models.EmployerSystem.Employer employer) : base(employer) { }
    }
}