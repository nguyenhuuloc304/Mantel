using Mantel.Common.Paging;
using Mantel.Grade_Service.Application.Features.Grades.Queries;
using Mantel.Grade_Service.Domain.Entities;
using Mantel.Grade_Service.Domain.Interfaces;
using MediatR;

namespace Mantel.Grade_Service.Application.Features.Grades.Handlers.QueryHandlers
{
    public class GradeQueryHandler :
        IRequestHandler<GetAllGradesQuery, PagedQueryResult<Grade>>,
        IRequestHandler<GetGradeByIdQuery, Grade>
    {
        private readonly IGradeRepository _gradeRepo;

        public GradeQueryHandler(IGradeRepository gradeRepo)
        {
            _gradeRepo = gradeRepo;
        }

        public async Task<PagedQueryResult<Grade>> Handle(GetAllGradesQuery query, CancellationToken cancellationToken)
        {
            var dataQueryable = await _gradeRepo.GetAllAsync();
            var data = dataQueryable.Skip((query.Page - 1) * query.PageSize)
                                    .Take(query.PageSize)
                                    .ToList();
            var totalItemCount = dataQueryable.Count();

            return new PagedQueryResult<Grade>(dataQueryable, totalItemCount, query.Page, query.PageSize);
        }

        public async Task<Grade> Handle(GetGradeByIdQuery query, CancellationToken cancellationToken)
        {
            return await _gradeRepo.GetByIdAsync(query.EntityId);
        }
    }
}
