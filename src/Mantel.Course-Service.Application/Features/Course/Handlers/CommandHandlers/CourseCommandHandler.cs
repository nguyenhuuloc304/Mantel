using AutoMapper;
using Mantel.Course_Service.Application.DTOs;
using Mantel.Course_Service.Application.Features.Courses.Commands;
using Mantel.Course_Service.Domain.Entities;
using Mantel.Course_Service.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Course_Service.Application.Features.Courses.Handlers.CommandHandlers
{
    public class CourseCommandHandler :
        IRequestHandler<CreateCourseCommand, CourseDto>,
        IRequestHandler<UpdateCourseCommand, CourseDto>,
        IRequestHandler<DeleteCourseCommand, CourseDto>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepo;

        public CourseCommandHandler(IMapper mapper,
            ICourseRepository CourseRepo)
        {
            _mapper = mapper;
            _courseRepo = CourseRepo;
        }

        public async Task<CourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var courseEntity = _mapper.Map<Course>(request);
            if (courseEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newCourse = await _courseRepo.AddAsync(courseEntity);
            var courseResponse = _mapper.Map<CourseDto>(newCourse);
            return courseResponse;
        }

        public async Task<CourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var courseEntity = _mapper.Map<Course>(request);
            if (courseEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            await _courseRepo.UpdateAsync(courseEntity.EntityId, courseEntity);
            var courseResponse = _mapper.Map<CourseDto>(courseEntity);
            return courseResponse;
        }

        public async Task<CourseDto> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepo.GetByIdAsync(request.EntityId);
            if (course != null)
            {
                await _courseRepo.DeleteAsync(course);
            }

            return new CourseDto();
        }
    }
}
