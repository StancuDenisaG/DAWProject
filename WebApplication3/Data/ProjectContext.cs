using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Models.Entities;

namespace WebApplication3.Data
{
    public class ProjectContext :  IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Accident> Accidents { get; set; }
        public DbSet<CarAccident> CarAccidents { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many :
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Cars)
                .WithOne(c => c.Owner);



            //one to one:
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Insurance)
                .WithOne(i => i.Car);


            //many to many

            modelBuilder.Entity<CarAccident>().HasKey(ca => new { ca.CarId, ca.AccidentId});


            modelBuilder.Entity<CarAccident>()
              .HasOne(ca => ca.Car)
              .WithMany(c => c.CarAccidents)
              .HasForeignKey(ca => ca.CarId);

            modelBuilder.Entity<CarAccident>()
                .HasOne(ca => ca.Accident)
                .WithMany(a => a.CarAccidents)
                .HasForeignKey(ca => ca.AccidentId);


            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });
        }
    }
}
