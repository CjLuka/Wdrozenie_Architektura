using Application.InterfaceRepository;
using Application.InterfaceServices;
using Application.Models.ServerSpecification;
using AutoMapper;
using Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServerSpecificationServices : IServerSpecificationServices
    {
        private readonly IServerSpecificationRepository _serverSpecificationRepository;
        private readonly IMapper _mapper;
        public ServerSpecificationServices(IServerSpecificationRepository serverSpecificationRepository, IMapper mapper)
        {
            _serverSpecificationRepository = serverSpecificationRepository;
            _mapper = mapper;
        }
        public async Task<List<ServerSpecificationViewModel>> GetAllAsync()
        {
            var Servers = await _serverSpecificationRepository.GetAllAsync();
            if (Servers.Any())
            {
                var mappedServers = _mapper.Map<List<ServerSpecificationViewModel>>(Servers);
                return mappedServers;
            }
            return null;
        }
        
    }
}
