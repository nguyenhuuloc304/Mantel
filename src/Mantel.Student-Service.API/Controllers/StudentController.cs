using Mantel.Common.Paging;
using Mantel.Student_Service.Application.DTOs;
using Mantel.Student_Service.Application.Features.Students.Commands;
using Mantel.Student_Service.Application.Features.Students.Queries;
using Mantel.Student_Service.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mantel.Student_Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<PagedQueryResult<Student>> Get()
        {
            return await _mediator.Send(new GetAllStudentsQuery());
        }

        // GET api/<StudentController>/5
        [HttpGet("{guidId}")]
        public async Task<IActionResult> Get(Guid guidId)
        {
            return Ok(await _mediator.Send(new GetStudentByIdQuery() { EntityId = guidId }));
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{guidId}")]
        public async Task<IActionResult> UpdateStudent(int guidId, [FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDto>> DeleteProduct(Guid id, [FromBody] DeleteStudentCommand command)
        {
            command.EntityId = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
