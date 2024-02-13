using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Queries.GetDetails
{
    public class GetDetailsServerQuery : IRequest<BaseResponse<GetDetailsServerDto>>
    {
        public int Id { get; set; }
    }
}
