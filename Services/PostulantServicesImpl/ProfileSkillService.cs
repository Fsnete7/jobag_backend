using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Domain.Services.Communication.PostulantResponse;
using jobagapi.Domain.Services.PostulantServices;

namespace jobagapi.Services.PostulantServicesImpl
{
    public class ProfileSkillService : IProfileSkillService
    {
        private readonly IProfileSkillRepository _profileSkillRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileSkillService(IProfileSkillRepository profileSkillRepository, IUnitOfWork unitOfWork)
        {
            _profileSkillRepository = profileSkillRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProfileSkill>> ListAsync()
            {
                return await _profileSkillRepository.ListAsync();
            }

            public async Task<IEnumerable<ProfileSkill>> ListByProfileIdAsync(int profileId)
            {
                return await _profileSkillRepository.ListByProfileIdAsync(profileId);
            }

            public async Task<IEnumerable<ProfileSkill>> ListBySkillIdAsync(int skillId)
            {
                return await _profileSkillRepository.ListBySkillIdAsync(skillId);

            }

            public async Task<ProfileSkillResponse> AssignProfileSkillAsync(int profileId, int skillId)
            {
                try
                {
                    await _profileSkillRepository.AssignProfileSkill(profileId, skillId);
                    await _unitOfWork.CompletedAsync();
                    ProfileSkill profileSkill =
                        await _profileSkillRepository.FindByProfileIdAndSkillId(profileId, skillId);
                    return new ProfileSkillResponse(profileSkill);

                }
                catch (Exception ex)
                {
                    return new ProfileSkillResponse($"An error ocurred while assigning Skill to Profile: {ex.Message}");
                }
            }

            public async Task<ProfileSkillResponse> UnassignProfileSkillAsync(int profileId, int skillId)
            {
                try
                {
                    ProfileSkill profileSkill =
                        await _profileSkillRepository.FindByProfileIdAndSkillId(profileId, skillId);

                    _profileSkillRepository.Remove(profileSkill);
                    await _unitOfWork.CompletedAsync();

                    return new ProfileSkillResponse(profileSkill);

                }
                catch (Exception ex)
                {
                    return new ProfileSkillResponse(
                        $"An error ocurred while unassigning Skill from Profile: {ex.Message}");
                }
            }
    }
}