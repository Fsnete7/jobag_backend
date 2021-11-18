using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.PostulantPersistence
{
    public class LanguageRepository: BaseRepository, ILanguageRepository
    {
        public LanguageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Language language)
        {
            await _context.Languages.AddAsync(language);
        }

        public void Remove(Language language)
        {
            _context.Languages.Remove(language);
        }

        public async Task<Language> FindById(int id)
        {
            return await _context.Languages.FindAsync(id);
        }

        public void Update(Language language)
        {
            _context.Languages.Update(language);
        }

        public async Task<IEnumerable<Language>> ListAsync()
        {
            return await _context.Languages.ToListAsync();
        }
    }
}