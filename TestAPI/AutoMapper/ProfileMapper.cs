using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI.Dto.Staff;
using TestAPI.Dto.Task;
using TestAPI.Models;

namespace TestAPI.AutoMapper
{
    public class ProfileMapper
    {
        public static void Configure()
        {
            Mapper.CreateMap<Staff, StaffDto>().ReverseMap();
            Mapper.CreateMap<Staff, StaffUpdateDto>().ReverseMap();
            Mapper.CreateMap<Task, TaskDto>().ReverseMap();
            Mapper.CreateMap<Task, TaskCreateDto>().ReverseMap();
        }
    }
}