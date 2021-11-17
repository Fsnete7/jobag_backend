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
    public class SkillService: ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SkillService(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            _skillRepository = skillRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SkillResponse> GetByIdAsync(int id)
        {
            var existingSkill = await _skillRepository.FindById(id);

            if (existingSkill == null)
                return new SkillResponse("Skill not found");
            return new SkillResponse(existingSkill);
        }

        public async Task<SkillResponse> SaveAsync(Skill skill)
        {
            try
            {
                await _skillRepository.AddAsync(skill);
                await _unitOfWork.CompletedAsync();
                return new SkillResponse(skill);
            }
            catch (Exception ex)
            {
                return new SkillResponse(
                    $"An error ocurred while saving the event skill: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Skill>> ListAsync()
        {
            return await _skillRepository.ListAsync();
        }

        public async Task<SkillResponse> DeleteAsync(int id)
        {
            var existingSkill = await _skillRepository.FindById(id);

            if (existingSkill == null)
                return new SkillResponse("Skill not found");

            try
            {
                _skillRepository.Remove(existingSkill);
                await _unitOfWork.CompletedAsync();

                return new SkillResponse(existingSkill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error has ocurred while deleting skill: {ex.Message}");
            }
        }

    }
}