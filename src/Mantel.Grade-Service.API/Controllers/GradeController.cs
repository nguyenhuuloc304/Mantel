using Mantel.Common.Paging;
using Mantel.Grade_Service.Application.DTOs;
using Mantel.Grade_Service.Application.Features.Grades.Commands;
using Mantel.Grade_Service.Application.Features.Grades.Queries;
using Mantel.Grade_Service.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mantel.Grade_Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GradeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<GradeController>
        [HttpGet]
        public async Task<PagedQueryResult<Grade>> Get()
        {
            return await _mediator.Send(new GetAllGradesQuery());
        }

        // GET api/<GradeController>/5
        [HttpGet("{guidId}")]
        public async Task<IActionResult> Get(Guid guidId)
        {
            return Ok(await _mediator.Send(new GetGradeByIdQuery() { EntityId = guidId }));
        }

        // POST api/<GradeController>
        [HttpPost]
        public async Task<IActionResult> CreateGrade([FromBody] CreateGradeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<GradeController>/5
        [HttpPut("{guidId}")]
        public async Task<IActionResult> UpdateGrade(int guidId, [FromBody] UpdateGradeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<GradeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GradeDto>> DeleteProduct(Guid id, [FromBody] DeleteGradeCommand command)
        {
            command.EntityId = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
