using Mantel.Common.Paging;
using Mantel.Course_Service.Application.DTOs;
using Mantel.Course_Service.Application.Features.Courses.Commands;
using Mantel.Course_Service.Application.Features.Courses.Queries;
using Mantel.Course_Service.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mantel.Course_Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public async Task<PagedQueryResult<Course>> Get()
        {
            return await _mediator.Send(new GetAllCoursesQuery());
        }

        // GET api/<CourseController>/5
        [HttpGet("{guidId}")]
        public async Task<IActionResult> Get(Guid guidId)
        {
            return Ok(await _mediator.Send(new GetCourseByIdQuery() { EntityId = guidId }));
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{guidId}")]
        public async Task<IActionResult> UpdateCourse(int guidId, [FromBody] UpdateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseDto>> DeleteProduct(Guid id, [FromBody] DeleteCourseCommand command)
        {
            command.EntityId = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
