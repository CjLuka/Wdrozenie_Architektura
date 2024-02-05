using Application.InterfaceServices;
using AutoMapper;
using Domain.Models.Entites;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ServerSpecificationController : Controller
    {
        private readonly IServerSpecificationServices _serverSpecificationServices;

        public ServerSpecificationController(IServerSpecificationServices serverSpecificationServices)
        {
            _serverSpecificationServices = serverSpecificationServices;
        }

        public async Task<IActionResult> Index()
        {
            var servers = await _serverSpecificationServices.GetAllAsync();
            return View(servers);
        }
    }
}
