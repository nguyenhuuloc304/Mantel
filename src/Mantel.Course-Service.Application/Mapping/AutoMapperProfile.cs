﻿using AutoMapper;
using Mantel.Course_Service.Application.DTOs;
using Mantel.Course_Service.Application.Features.Courses.Commands;
using Mantel.Course_Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CourseDto, Course>();
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();
        }
    }
}
