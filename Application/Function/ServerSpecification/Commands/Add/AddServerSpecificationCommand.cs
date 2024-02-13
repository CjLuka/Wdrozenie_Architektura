using Application.Models.ServerSpecification;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Commands.Add
{
    public class AddServerSpecificationCommand : IRequest<BaseResponse<AddServerSpecificationCommand>> 
    {
        public int NumberOfCores { get; set; }
        public int NumberOfRam { get; set; }
        public int DiskSizeInGB { get; set; }
        public string IpAddress { get; set; }
        public string DomainName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; } = true;
    }
}
