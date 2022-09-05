using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Entities;
using WebApplication3.Repositories.GenericRepository;

namespace WebApplication3.Repositories.CarrRepository
{
    public class CarRepository: GenericRepository<Car>, ICarRepository
    {
        public CarRepository(ProjectContext context) : base(context) { }
       
        public async Task<List<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetById(int id)
        {
            return await _context.Cars.Where(a => a.Id == id).FirstOrDefaultAsync();
        }





    }
}
