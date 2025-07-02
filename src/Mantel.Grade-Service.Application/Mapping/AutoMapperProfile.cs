using AutoMapper;
using Mantel.Grade_Service.Application.DTOs;
using Mantel.Grade_Service.Application.Features.Grades.Commands;
using Mantel.Grade_Service.Domain.Entities;

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
