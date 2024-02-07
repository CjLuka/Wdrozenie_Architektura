using Application.Models.Account;
using Application.Models.Auth;
using Application.Models.ServerSpecification;
using AutoMapper;
using Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //ServerSpecification
            CreateMap<ServerSpecification, ServerSpecificationViewModel>().ReverseMap();

            CreateMap<ServerSpecification, AddServerSpecificationViewModel>().ReverseMap();

            //Account
            CreateMap<User, UsersViewModel>().ReverseMap();
            
            CreateMap<User, AddUserViewModel>().ReverseMap();

            CreateMap<User, UpdateUserViewModel>().ReverseMap();

            CreateMap<UsersViewModel, UpdateUserViewModel>().ReverseMap();
            
            CreateMap<User, Register>().ReverseMap();
        }
    }
}
