using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.DTOS;
using TaskManagment.Models;

namespace TaskManagment.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskUnitDTO, TaskUnit>().ReverseMap();
            CreateMap<AssignedUser, GetAssignedUserDTO>().ReverseMap();
            CreateMap<TaskUnit, ViewTaskUnitDTO>().ForMember(dto => dto.AssignedUsers, c => c.MapFrom(x => x.AssignedUserTaskUnits.Select(x=> x.AssignedUser))).ReverseMap();                                              
        }
    }
}
