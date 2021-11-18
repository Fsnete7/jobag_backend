<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.PostulantPersistence
{
    public class PostulantRepository: BaseRepository, IPostulantRepository
    {
        public PostulantRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Postulant>> ListAsync()
        {
            return await _context.Postulants.ToListAsync();
        }

        public async Task<Postulant> FindById(int id)
        {
            return await _context.Postulants.FindAsync(id);
        }

        public void Update(Postulant postulant)
        {
            _context.Postulants.Update(postulant);
        }

        public void Remove(Postulant postulant)
        {
            _context.Postulants.Remove(postulant);
        }
        
        public async Task AddAsync(Postulant postulant)
        {
            await _context.Postulants.AddAsync(postulant);
        }
=======
﻿namespace jobagapi.Persistence.Repositories.PostulantRepositories
{
    public class PostulantRepository
    {
        
>>>>>>> main
    }
}