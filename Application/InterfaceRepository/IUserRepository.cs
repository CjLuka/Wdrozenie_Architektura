using Application.Models.Auth;
using Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IUserRepository : IAsyncRepository<User> 
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> Register(User user);
    }
}
