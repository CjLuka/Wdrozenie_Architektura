﻿using Application.Models.ServerSpecification;
using AutoMapper;
using Domain.Models.Entites;

namespace MVC.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //ServerSpecification
            CreateMap<ServerSpecification, ServerSpecificationViewModel>().ReverseMap();
        }
    }
}
