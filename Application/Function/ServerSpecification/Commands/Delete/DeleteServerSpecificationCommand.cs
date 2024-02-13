using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Commands.Delete
{
    public class DeleteServerSpecificationCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
