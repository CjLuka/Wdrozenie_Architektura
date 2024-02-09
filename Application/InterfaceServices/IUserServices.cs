using Application.Models.Account;
using Application.Models.Auth;
using Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceServices
{
    public interface IUserServices
    {
        Task<List<UsersViewModel>> GetAllAsync();
        Task<UsersViewModel> GetByIdAsync(Guid id);
        Task<AddUserViewModel> AddAsync(AddUserViewModel addUserViewModel);
        Task Update(UpdateUserViewModel updateUserViewModel);
        Task<Register> Register(Register register);
        Task<SignInResult> Login(LoginViewModel login);
        public void Logout();
        Task<LoginGoogle> ProcessExternalLogin(string returnUrl, string remoteError);
    }
}
