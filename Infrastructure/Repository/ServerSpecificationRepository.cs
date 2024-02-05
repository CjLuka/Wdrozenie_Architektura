using Application.InterfaceRepository;
using Domain.Models.Entites;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ServerSpecificationRepository : AsyncRepository<ServerSpecification>, IServerSpecificationRepository
    {
        public ServerSpecificationRepository(AppDbContext context) : base(context)
        {
            
        }

    }
}
