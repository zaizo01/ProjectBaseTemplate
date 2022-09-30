using AutoMapper;
using ProjectBase.Domain.Entities;
using ProjectBase.Infraestructure.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBase.Infraestructure.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserPostDTO>().ReverseMap();
        }
    }
}
