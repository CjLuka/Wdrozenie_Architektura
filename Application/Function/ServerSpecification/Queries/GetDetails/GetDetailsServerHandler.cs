using Application.InterfaceRepository;
using Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Queries.GetDetails
{
    public class GetDetailsServerHandler : IRequestHandler<GetDetailsServerQuery, BaseResponse<GetDetailsServerDto>>
    {
        private readonly IMapper _mapper;
        private readonly IServerSpecificationRepository _specificationRepository;

        public GetDetailsServerHandler(IMapper mapper, IServerSpecificationRepository serverSpecificationRepository)
        {
            _mapper = mapper;
            _specificationRepository = serverSpecificationRepository;
        }
        public async Task<BaseResponse<GetDetailsServerDto>> Handle(GetDetailsServerQuery request, CancellationToken cancellationToken)
        {
            var server = await _specificationRepository.GetByIdAsync(request.Id);

            if (server == null)
            {
                return new BaseResponse<GetDetailsServerDto>(false, "Brak serweru o podanym Id");
            }
            return new BaseResponse<GetDetailsServerDto>(_mapper.Map<GetDetailsServerDto>(server), true);
            
        }
    }
}
