using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Repositories.OwnerrRepository;
using WebApplication3.Repositories.SessionTokenRepositoryy;
using WebApplication3.Repositories.UserrRepository;


namespace WebApplication3.Repositories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly ProjectContext _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;
        private IOwnerRepository _owner;
        public RepositoryWrapper(ProjectContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new OwnerTokenRepository(_context);
                return _sessionToken;
            }
        }

        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null) _owner = new OwnerRepository(_context);
                return _owner;
            }
        }
    public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    
}
}
