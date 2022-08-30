using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Repositories.OwnerrRepository;
using WebApplication3.Repositories.SessionTokenRepositoryy;
using WebApplication3.Repositories.UserrRepository;

namespace WebApplication3.Repositories
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner{ get;}
        
        IUserRepository User { get; }

        ISessionTokenRepository SessionToken { get; }

        Task SaveAsync();
    }
}
