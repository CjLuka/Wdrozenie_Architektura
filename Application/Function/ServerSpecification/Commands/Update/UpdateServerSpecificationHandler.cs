using Application.Function.ServerSpecification.Commands.Add;
using Application.InterfaceRepository;
using Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Commands.Update
{
    public class UpdateServerSpecificationHandler : IRequestHandler<UpdateServerSpecificationCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServerSpecificationRepository _serverSpecificationRepository;

        public UpdateServerSpecificationHandler(IMapper mapper, IServerSpecificationRepository serverSpecificationRepository)
        {
            _mapper = mapper;
            _serverSpecificationRepository = serverSpecificationRepository;
        }
        public async Task<BaseResponse> Handle(UpdateServerSpecificationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateServerSpecificationValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(false, validationResult.ToString());

            var server = await _serverSpecificationRepository.GetByIdAsync(request.Id);

            server.NumberOfRam = request.NumberOfRam;
            server.DomainName = request.DomainName;
            server.NumberOfCores = request.NumberOfCores;
            server.UpdateDate = DateTime.UtcNow;
            server.CreateDate = server.CreateDate;
            server.DiskSizeInGB = request.DiskSizeInGB;
            server.Status = request.Status;

            await _serverSpecificationRepository.UpdateAsync(server);

            return new BaseResponse(true);
        }


    }
}
