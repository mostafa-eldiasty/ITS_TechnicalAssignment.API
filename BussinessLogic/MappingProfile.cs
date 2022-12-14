using AutoMapper;
using ITS_TechnicalAssignment.DataAccess.Models;
using ITS_TechnicalAssignment.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS_TechnicalAssignment.BussinessLogic
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
