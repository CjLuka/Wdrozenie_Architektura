using Application.InterfaceRepository;
using Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Commands.Delete
{
    public class DeleteServerSpecificationHandler : IRequestHandler<DeleteServerSpecificationCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServerSpecificationRepository _serverSpecificationRepository;

        public DeleteServerSpecificationHandler(IMapper mapper, IServerSpecificationRepository serverSpecificationRepository)
        {
            _mapper = mapper;
            _serverSpecificationRepository = serverSpecificationRepository;
        }
        public async Task<BaseResponse> Handle(DeleteServerSpecificationCommand request, CancellationToken cancellationToken)
        {
            if (!(request.Id > 0))
            {
                return new BaseResponse(false, "Id nie może być mniejsze lub równe 0");
            }

            var server = await _serverSpecificationRepository.GetByIdAsync(request.Id);

            if (server == null)
            {
                return new BaseResponse(false, "Brak serwera o podanym Id");
            }

            await _serverSpecificationRepository.DeleteAsync(server);
            return new BaseResponse(true, "Usunięto serwer");
        }
    }
}
