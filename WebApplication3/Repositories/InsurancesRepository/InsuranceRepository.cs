using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Entities;
using WebApplication3.Models.Entities.DTOs;
using WebApplication3.Repositories.GenericRepository;

namespace WebApplication3.Repositories.InsurancesRepository
{
    public class InsuranceRepository : GenericRepository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(ProjectContext context) : base(context) { } //injectam contextul 

        public async Task<List<Insurance>> GetAllInsurances()
        {
            return await _context.Insurances.ToListAsync();
        }

        public async Task<Insurance> GetById(int id)
        {
            return await _context.Insurances.Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
