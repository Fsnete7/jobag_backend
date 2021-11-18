﻿using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Services.Communication;
using jobagapi.Domain.Services.Communication.PostulantResponse;
using jobagapi.Domain.Services.Communication.SubscriptionResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface IUserService
    {
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> SaveAsync(User user);
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> DeleteAsync(int id);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    }
}