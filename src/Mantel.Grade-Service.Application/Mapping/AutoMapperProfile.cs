using AutoMapper;
using Mantel.Grade_Service.Application.DTOs;
using Mantel.Grade_Service.Application.Features.Grades.Commands;
using Mantel.Grade_Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mantel.Grade_Service.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GradeDto, Grade>();
            CreateMap<Grade, GradeDto>();
            CreateMap<CreateGradeCommand, Grade>();
            CreateMap<UpdateGradeCommand, Grade>();
        }
    }
}
