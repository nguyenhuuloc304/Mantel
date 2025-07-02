using AutoMapper;
using Mantel.Student_Service.Application.DTOs;
using Mantel.Student_Service.Application.Features.Students.Commands;
using Mantel.Student_Service.Domain.Entities;

namespace Mantel.Student_Service.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<UpdateStudentCommand, Student>();
        }
    }
}
