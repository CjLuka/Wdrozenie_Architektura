using Application.InterfaceServices;
using Application.Models.Auth;
using Domain.Models.Entites;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly SignInManager<User> _signInMannager;
        private readonly UserManager<User> _userManager;
        public AuthController(IUserServices userServices, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userServices = userServices;
            _signInMannager = signInManager;
            _userManager = userManager;
        }
        //Widok logowania
        public async Task <IActionResult> Login()
        {
            return View();
        }
        //Endpoint obsługujący zalogowanie
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel login)
        {
            await _userServices.Login(login);

            return RedirectToAction("Index", "Home");
        }
        //Endpoint do wylogowania
        public async Task<IActionResult> Logout()
        {
            _userServices.Logout();
            return RedirectToAction("Index", "Home");
        }
        //Widok rejestracji
        public async Task<IActionResult> Register()
        {
            var emailFromExternalLogin = TempData["Email"];
            if (emailFromExternalLogin != null)
            {
                TempData["Email"] = emailFromExternalLogin;
            }
            return View();
        }

        //Endpoint odbsługujący rejestrację
        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            await _userServices.Register(register);

            return RedirectToAction("Index", "Home");
        }



        public async Task ExternalLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);

            var claims = result.Principal.Identities.FirstOrDefault().Claims;
            var subClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            if (subClaim != null)
            {
                var existingUser = await _userManager.FindByEmailAsync(subClaim);
                if (existingUser != null)
                {
                    await _signInMannager.SignInAsync(existingUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ReturnUrl"] = Url.Action("Index", "Home");
                    TempData["Email"] = subClaim;
                    return RedirectToAction("Register");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }       
        }
    }
}
