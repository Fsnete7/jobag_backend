namespace jobagapi.Domain.Services.Communication.EmployerResponse
{
    public class SectorResponse: BaseResponse<Models.EmployerSystem.Sector>
    {
        public SectorResponse(string message) : base(message) { }

        public SectorResponse(Models.EmployerSystem.Sector sector) : base(sector) { }
    }
  
}