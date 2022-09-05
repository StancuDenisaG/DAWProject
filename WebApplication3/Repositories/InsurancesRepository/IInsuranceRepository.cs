using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Models.Entities.DTOs;
using WebApplication3.Repositories.GenericRepository;

namespace WebApplication3.Repositories.InsurancesRepository
{
    public interface IInsuranceRepository : IGenericRepository<Insurance>
    {


        Task<List<Insurance>> GetAllInsurances();
        Task<Insurance> GetById(int id);


    }
}
