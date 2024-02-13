using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Function.ServerSpecification.Queries.GetAll
{
    public class GetAllServersDto
    {
        public int Id { get; set; }
        public int NumberOfCores { get; set; }
        public int NumberOfRam { get; set; }
        public int DiskSizeInGB { get; set; }
        public string IpAddress { get; set; }
        public string DomainName { get; set; }
    }
}
