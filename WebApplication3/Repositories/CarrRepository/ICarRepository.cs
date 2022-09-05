using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Repositories.GenericRepository;

namespace WebApplication3.Repositories.CarrRepository
{
    public interface ICarRepository: IGenericRepository<Car>
    {

        //  Task<Owner> GetByLastName(string lastname);
        Task<List<Car>> GetAllCars();
        Task<Car> GetById(int id);
    }
}
