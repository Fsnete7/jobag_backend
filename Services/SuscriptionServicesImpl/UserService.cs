using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SuscriptionSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.SuscriptionRepositories;
using jobagapi.Domain.Services.Communication;
using jobagapi.Domain.Services.Communication.SuscriptionResponse;
using jobagapi.Domain.Services.SuscriptionServices;

namespace jobagapi.Services.SuscriptionServicesImpl
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if(existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving the event user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingPerformer = await _userRepository.FindById(id);

            if (existingPerformer == null)
                return new UserResponse("User not found");

            try
            {
                _userRepository.Remove(existingPerformer);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingPerformer);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error has ocurred while deleting user: {ex.Message}");
            }
        }

        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}