using Application.InterfaceServices;
using Application.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        
        //Wyświetlenie wszystkich użytkowników
        public async Task <IActionResult> Index()
        {
            var users = await _userServices.GetAllAsync();
            return View(users);
        }

        //Wyświetlenie formularza do edycji
        public async Task <IActionResult> Edit(Guid id)
        {
            var user = await _userServices.GetByIdAsync(id);
            return View(user);
        }

        //Endpoint do aktualizacju
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel updateUserViewModel)
        {           
            await _userServices.Update(updateUserViewModel);

            return RedirectToAction("Index", "User");
        }

        //Wyświetlenie formularza tworzenia nowego konta
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //Endpoint do tworzenia rekordu
        [HttpPost]
        public async Task<IActionResult> Create(AddUserViewModel addUserViewModel)
        {
            await _userServices.AddAsync(addUserViewModel);

            return RedirectToAction("Index", "User");
        }
    }
}
