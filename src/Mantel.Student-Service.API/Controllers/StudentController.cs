using Mantel.Student_Service.Application.DTOs;
using Mantel.Student_Service.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mantel.Student_Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _student;

        public StudentController(IStudentService student)
        {
            _student = student;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _student.GetAllStudents());
        }

        // GET api/<StudentController>/5
        [HttpGet("{guidId}")]
        public async Task<IActionResult> Get(Guid guidId)
        {
            return Ok(await _student.GetAStudent(guidId));
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] CreateStudentRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            // Call the service to create a student
            _student.CreateAStudent(request);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{guidId}")]
        public void Put(int guidId, [FromBody] CreateStudentRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            // Call the service to update a student
            _student.CreateAStudent(request);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
