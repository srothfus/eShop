using AutoMapper;
using eShop.DTOs;
using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Breakdown, BreakdownDTO>();
            Mapper.CreateMap<BreakdownDTO, Breakdown>();
        }
    }
}