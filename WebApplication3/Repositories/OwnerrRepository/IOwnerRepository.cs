using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Entities.DTOs;
using WebApplication3.Repositories.GenericRepository;

namespace WebApplication3.Repositories.OwnerrRepository
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {

        Task<Owner> GetByLastName(string lastname);
        Task<Owner> GetById(int id);
        Task<List<Owner>> GetAllOwners();

        //void UpdateOwner(int id, OwnerDTO dto);
    }
}
