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

namespace Application.Function.ServerSpecification.Commands.Add
{
    public class AddServerSpecificationHandler : IRequestHandler<AddServerSpecificationCommand, BaseResponse<AddServerSpecificationCommand>>
    {
        private readonly IMapper _mapper;
        private readonly IServerSpecificationRepository _serverSpecificationRepository;

        public AddServerSpecificationHandler(IMapper mapper, IServerSpecificationRepository serverSpecificationRepository)
        {
            _mapper = mapper;
            _serverSpecificationRepository = serverSpecificationRepository;
        }

        public async Task<BaseResponse<AddServerSpecificationCommand>> Handle(AddServerSpecificationCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddServerSpecificationValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse<AddServerSpecificationCommand>(false, validationResult.ToString());


            var server = _mapper.Map<Domain.Models.Entites.ServerSpecification>(request);

            server.Status = true;

            await _serverSpecificationRepository.AddAsync(server);

            return new BaseResponse<AddServerSpecificationCommand>(_mapper.Map< AddServerSpecificationCommand>(server), true);
        }

    }
}
