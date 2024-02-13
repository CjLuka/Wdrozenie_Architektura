using Application.Function.ServerSpecification.Commands.Update;
using Application.Models.ServerSpecification;
using Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceServices
{
    public interface IServerSpecificationServices
    {
        Task<List<ServerSpecificationViewModel>> GetAllAsync();
        Task<UpdateServerSpecificationCommand> GetByIdAsync(int id);
        //Task<AddServerSpecificationViewModel> AddAsync();
    }
}
