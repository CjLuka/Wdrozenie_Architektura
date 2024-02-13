using Application.InterfaceRepository;
using Application.InterfaceServices;
using Application.Models.Account;
using Application.Models.Auth;
using AutoMapper;
using Domain.Models.Entites;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserServices(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        //Dodanie nowego użytkownika
        public async Task<AddUserViewModel> AddAsync(AddUserViewModel addUserViewModel)
        {
            addUserViewModel.NormalizedUserName = addUserViewModel.UserName.ToUpper();
            addUserViewModel.NormalizedEmail = addUserViewModel.Email.ToUpper();
            addUserViewModel.PasswordHash = new PasswordHasher<AddUserViewModel>().HashPassword(addUserViewModel, addUserViewModel.PasswordHash);
            addUserViewModel.SecurityStamp = Guid.NewGuid().ToString();

            var addUser = await _userRepository.AddAsync(_mapper.Map<User>(addUserViewModel));
            
            if(addUser == null)
            {
                return null;
            }
            await _userManager.AddToRoleAsync(addUser, "User");

            return addUserViewModel;
        }

        //Rejestracja
        public async Task<Register> Register(Register register)
        {
            register.NormalizedUserName = register.UserName.ToUpper();
            register.NormalizedEmail = register.Email.ToUpper();
            register.PasswordHash = new PasswordHasher<Register>().HashPassword(register, register.PasswordHash);
            register.SecurityStamp = Guid.NewGuid().ToString();

            var newUser = await _userRepository.Register(_mapper.Map<User>(register));

            if(newUser == null)
            {
                return null;
            }
            await _userManager.AddToRoleAsync(newUser, "User");
            return register;
        }

        //Pobranie wszystkich użytkonikwów
        public async Task<List<UsersViewModel>> GetAllAsync()
        {
            var allUsers = await _userRepository.GetAllAsync();
            if (allUsers.Count != 0)
            {
                var users = _mapper.Map<List<UsersViewModel>>(allUsers);
                return users;
            }
            return null;
        }

        //Pobranie konkretnego użytkownika po Id
        public async Task<UsersViewModel> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UsersViewModel>(user);
        }

        //Logowanie
        public async Task<SignInResult> Login(LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return SignInResult.Success;
                    }
                    return SignInResult.Failed;
                }
            }
            return SignInResult.Failed;
        }

        //Funkcja do wylogowania
        public void Logout()
        {
            _signInManager.SignOutAsync();
        }

        //Aktualizacja użytkownika
        public async Task Update(UpdateUserViewModel updateUserViewModel)
        {
            var userFromBase = await _userRepository.GetByIdAsync(updateUserViewModel.Id);
            
            if(userFromBase == null)
            {
                return;
            }

            userFromBase.UserName = updateUserViewModel.UserName;
            userFromBase.Email = updateUserViewModel.Email;
            userFromBase.NormalizedUserName = userFromBase.UserName.ToUpper();
            userFromBase.NormalizedEmail = userFromBase.Email.ToUpper();

            var user = _userRepository.UpdateAsync(_mapper.Map<User>(userFromBase));
            if (user == null)
            {
                return;
            }
        }
        
    }
}
