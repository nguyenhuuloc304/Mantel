using AutoMapper;
using Mantel.Student_Service.Application.DTOs;
using Mantel.Student_Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Student_Service.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateStudentRequestDto, Student>();
        }
    }
}
