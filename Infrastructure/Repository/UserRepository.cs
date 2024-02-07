using Application.InterfaceRepository;
using Application.Models.Auth;
using Domain.Models.Entites;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        //private readonly UserManager<User> _userManager;
        public UserRepository(AppDbContext context/*, UserManager<User> userManager*/) : base(context)
        {
            //_userManager = userManager;
        }

        new public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
