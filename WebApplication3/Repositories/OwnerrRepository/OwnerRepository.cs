using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Entities;
using WebApplication3.Entities.DTOs;
using WebApplication3.Repositories.GenericRepository;

namespace WebApplication3.Repositories.OwnerrRepository
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {

        public OwnerRepository(ProjectContext context) : base(context) { } //injectam contextul 

        public async Task<List<Owner>> GetAllOwners()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task<Owner> GetById(int id)
        {
            return await _context.Owners.Where(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Owner> GetByLastName(string lastname)
        {
            return await _context.Owners.Where(o => o.LastName.Equals(lastname)).FirstOrDefaultAsync();
        }

     




    }
}
