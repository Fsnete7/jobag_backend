using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.SubscriptionRepositories;
using jobagapi.Domain.Services.Communication;
using jobagapi.Domain.Services.Communication.SubscriptionResponse;
using jobagapi.Domain.Services.SubscriptionServices;

namespace jobagapi.Services.SubscriptionServicesImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public UserService(IUserRepository user, IUnitOfWork unitOfWork)
        {
            _userRepository = user;
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
        //post
        public async Task<SaveUserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompletedAsync();

                return new SaveUserResponse(user);
            }
            catch (Exception e)
            {
                return new SaveUserResponse($"An error occured while saving the user: ${e.Message}");
            }
        }
        //update
        public async Task<SaveUserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            if (existingUser == null)
                return new SaveUserResponse("User not found.");

            existingUser.FirstName = user.FirstName;  
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.PassWord = user.PassWord;
            
            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompletedAsync();

                return new SaveUserResponse(existingUser);
            }
            catch (Exception e)
            {
                return new SaveUserResponse($"An error occured while updating the user: ${ e.Message }");
            }
        }
        //delete
        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            if (existingUser == null) return new UserResponse("User no found.");
            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompletedAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occured while delete the user: ${e.Message}");
            }
        }
    }
}