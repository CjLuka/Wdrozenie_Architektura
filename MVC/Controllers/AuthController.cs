using Application.InterfaceServices;
using Application.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserServices _userServices;
        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
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
            return View();
        }

        //Endpoint odbsługujący rejestrację
        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            await _userServices.Register(register);

            return RedirectToAction("Index", "Home");
        }
        

    }
}
