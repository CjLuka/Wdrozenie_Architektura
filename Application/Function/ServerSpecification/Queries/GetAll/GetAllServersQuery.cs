using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Queries.GetAll
{
    public class GetAllServersQuery : IRequest<BaseResponse<List<GetAllServersDto>>>
    {

    }
}
