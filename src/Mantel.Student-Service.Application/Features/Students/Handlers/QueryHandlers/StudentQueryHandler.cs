using Mantel.Common.Paging;
using Mantel.Student_Service.Application.Features.Students.Queries;
using Mantel.Student_Service.Domain.Entities;
using Mantel.Student_Service.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Student_Service.Application.Features.Students.Handlers.QueryHandlers
{
    public class StudentQueryHandler :
        IRequestHandler<GetAllStudentsQuery, PagedQueryResult<Student>>,
        IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IStudentRepository _studentRepo;

        public StudentQueryHandler(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<PagedQueryResult<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
        {
            var dataQueryable = _studentRepo.GetAllStudent();
            var data = await dataQueryable.Skip((query.Page - 1) * query.PageSize)
                                    .Take(query.PageSize)
                                    .ToListAsync();
            var totalItemCount = dataQueryable.Count();

            return new PagedQueryResult<Student>(data, totalItemCount, query.Page, query.PageSize);
        }

        public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepo.GetByIdAsync(query.EntityId);
        }
    }
}
