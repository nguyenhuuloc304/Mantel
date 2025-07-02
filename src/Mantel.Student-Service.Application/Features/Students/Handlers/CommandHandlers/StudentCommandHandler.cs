using AutoMapper;
using Mantel.Student_Service.Application.DTOs;
using Mantel.Student_Service.Application.Features.Students.Commands;
using Mantel.Student_Service.Domain.Entities;
using Mantel.Student_Service.Domain.Interfaces;
using MediatR;

namespace Mantel.Student_Service.Application.Features.Students.Handlers.CommandHandlers
{
    public class StudentCommandHandler :
        IRequestHandler<CreateStudentCommand, StudentDto>,
        IRequestHandler<UpdateStudentCommand, StudentDto>,
        IRequestHandler<DeleteStudentCommand, StudentDto>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepo;

        public StudentCommandHandler(IMapper mapper,
            IStudentRepository StudentRepo)
        {
            _mapper = mapper;
            _studentRepo = StudentRepo;
        }

        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Student>(request);
            if (studentEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newStudent = await _studentRepo.AddAsync(studentEntity);
            var studentResponse = _mapper.Map<StudentDto>(newStudent);
            return studentResponse;
        }

        public async Task<StudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Student>(request);
            if (studentEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            await _studentRepo.UpdateAsync(studentEntity.EntityId, studentEntity);
            var studentResponse = _mapper.Map<StudentDto>(studentEntity);
            return studentResponse;
        }

        public async Task<StudentDto> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepo.GetByIdAsync(request.EntityId);
            if (student != null)
            {
                await _studentRepo.DeleteAsync(student);
            }

            return new StudentDto();
        }
    }
}
