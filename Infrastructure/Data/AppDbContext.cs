using Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<ServerSpecification> ServerSpecifications { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<IdentityRole<Guid>>()
            {
                new IdentityRole<Guid>()
                    {
                        Name = "User",
                        NormalizedName = "User",
                        Id = new Guid("f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b"),
                        ConcurrencyStamp = "f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b"
                    },
                    new IdentityRole<Guid>()
                    {
                        Name = "Admin",
                        NormalizedName = "Admin",
                        Id = new Guid("96ae491d-ab67-489c-ab00-8eb57d05f11a"),
                        ConcurrencyStamp = "96ae491d-ab67-489c-ab00-8eb57d05f11a"
                    }
            };
            var admin = new User()
            {
                Id = new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                UserName = "Luka",
                Email = "luka@o2.pl",
                NormalizedUserName = "Luka".ToUpper(),
                NormalizedEmail = "luka@o2.pl".ToUpper(),
            };

            admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "Test123");

            var adminRoles = new List<IdentityUserRole<Guid>>()
                {
                    new IdentityUserRole<Guid>()
                    {
                        RoleId = roles[0].Id,
                        UserId = admin.Id
                    },
                    new IdentityUserRole<Guid>()
                    {
                        RoleId = roles[1].Id,
                        UserId = admin.Id
                    }
                };

            builder.Entity<IdentityRole<Guid>>().HasData(roles);
            builder.Entity<User>().HasData(admin);
            builder.Entity<IdentityUserRole<Guid>>().HasData(adminRoles);
        }
    }
}
