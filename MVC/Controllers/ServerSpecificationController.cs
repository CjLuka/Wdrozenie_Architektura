using Application.Function.ServerSpecification.Commands.Add;
using Application.Function.ServerSpecification.Commands.Delete;
using Application.Function.ServerSpecification.Commands.Update;
using Application.Function.ServerSpecification.Queries.GetAll;
using Application.Function.ServerSpecification.Queries.GetDetails;
using Application.InterfaceServices;
using AutoMapper;
using Domain.Models.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ServerSpecificationController : Controller
    {
        private readonly IServerSpecificationServices _serverSpecificationServices;
        private readonly IMediator _mediator;

        public ServerSpecificationController(IServerSpecificationServices serverSpecificationServices, IMediator mediator)
        {
            _serverSpecificationServices = serverSpecificationServices;
            _mediator = mediator;
        }

        //Wyświetlanie wszystkich serwerów
        [HttpGet]
        public async Task<ActionResult<List<GetAllServersDto>>> Index()
        {
            var servers = await _mediator.Send(new GetAllServersQuery());
            return View(servers.Data);
        }


        //Wyświetlenie formularza do utworzenia nowego rekordu
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        //Dodawanie nowego serwera
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddServerSpecificationCommand request)
        {
            var server = await _mediator.Send(request);
            return RedirectToAction("Index", "ServerSpecification");
        }

        //[HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] DeleteServerSpecificationCommand request)
        {
            await _mediator.Send(request);

            return RedirectToAction("Index", "ServerSpecification");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GetDetailsServerDto>> Update(int id)
        {
            var server = await _mediator.Send(new GetDetailsServerQuery{ Id = id});
            return View(server.Data);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromForm] UpdateServerSpecificationCommand request)
        {
            var server = await _mediator.Send(request);
            return RedirectToAction("Index", "ServerSpecification");
        }
    }
}
