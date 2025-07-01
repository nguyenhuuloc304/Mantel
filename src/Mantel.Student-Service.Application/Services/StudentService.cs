using AutoMapper;
using Mantel.Student_Service.Application.DTOs;
using Mantel.Student_Service.Application.Interfaces;
using Mantel.Student_Service.Domain.Entities;
using Mantel.Student_Service.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Student_Service.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IMapper mapper,
            IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudent(Guid studentGuid)
        {
            var result = await _studentRepository.GetById(studentGuid);
            return result;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var result = await _studentRepository.GetAllAsync();
            return result;
        }

        public async Task<Student> CreateStudent(CreateStudentRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Student cannot be null");
            }

            var student = _mapper.Map<Student>(request);
            var result = await _studentRepository.CreateAsync(student);
            return result;
        }

        public async Task<Student> UpdateStudent(CreateStudentRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Student cannot be null");
            }

            var student = _mapper.Map<Student>(request);
            var result = await _studentRepository.CreateAsync(student);
            return result;
        }

        public async Task<Student> DeleteStudent(Guid guidId)
        {
            

            var student = _mapper.Map<Student>(request);
            var result = await _studentRepository.CreateAsync(student);
            return result;
        }
    }
}