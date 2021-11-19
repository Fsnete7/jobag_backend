using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.PostulantPersistence
{
    public class SkillRepository: BaseRepository, ISkillRepository
    {
        public SkillRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public void Remove(Skill skill)
        {
            _context.Skills.Remove(skill);
        }

        public void Update(Skill skill)
        {
            _context.Skills.Update(skill);

        }

        public async Task<Skill> FindById(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<IEnumerable<Skill>> ListAsync()
        {
            return await _context.Skills.ToListAsync();
        }
    }
}