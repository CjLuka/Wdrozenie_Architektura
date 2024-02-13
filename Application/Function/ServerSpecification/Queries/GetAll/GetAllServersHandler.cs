using Application.InterfaceRepository;
using Application.Response;
using AutoMapper;
using Domain.Models.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Queries.GetAll
{
    public class GetAllServersHandler : IRequestHandler<GetAllServersQuery, BaseResponse<List<GetAllServersDto>>>
    {
        private readonly IServerSpecificationRepository _serverSpecificationRepository;
        private readonly IMapper _mapper;

        public GetAllServersHandler(IServerSpecificationRepository serverSpecificationRepository, IMapper mapper)
        {
            _serverSpecificationRepository = serverSpecificationRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<GetAllServersDto>>> Handle(GetAllServersQuery request, CancellationToken cancellationToken)
        {
            var servers = await _serverSpecificationRepository.GetAllAsync();

            if(servers.Count == 0 || servers == null)
            {
                return new BaseResponse<List<GetAllServersDto>>(false, "Brak rekordów");
            }
            return new BaseResponse<List<GetAllServersDto>>(_mapper.Map<List<GetAllServersDto>>(servers), true);
        }
    }
}
