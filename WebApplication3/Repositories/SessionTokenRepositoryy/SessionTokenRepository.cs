using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models.Entities;
using WebApplication3.Repositories.GenericRepository;

namespace WebApplication3.Repositories.SessionTokenRepositoryy
{
    public class OwnerTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public OwnerTokenRepository(ProjectContext context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
