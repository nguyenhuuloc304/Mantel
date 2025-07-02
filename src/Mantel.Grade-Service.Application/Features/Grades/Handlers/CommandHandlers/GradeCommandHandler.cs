using AutoMapper;
using Mantel.Grade_Service.Application.DTOs;
using Mantel.Grade_Service.Application.Features.Grades.Commands;
using Mantel.Grade_Service.Domain.Entities;
using Mantel.Grade_Service.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantel.Grade_Service.Application.Features.Grades.Handlers.CommandHandlers
{
    public class GradeCommandHandler :
        IRequestHandler<CreateGradeCommand, GradeDto>,
        IRequestHandler<UpdateGradeCommand, GradeDto>,
        IRequestHandler<DeleteGradeCommand, GradeDto>
    {
        private readonly IMapper _mapper;
        private readonly IGradeRepository _gradeRepo;

        public GradeCommandHandler(IMapper mapper,
            IGradeRepository gradeRepo)
        {
            _mapper = mapper;
            _gradeRepo = gradeRepo;
        }

        public async Task<GradeDto> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            var gradeEntity = _mapper.Map<Grade>(request);
            if (gradeEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newGrade = await _gradeRepo.AddAsync(gradeEntity);
            var gradeResponse = _mapper.Map<GradeDto>(newGrade);
            return gradeResponse;
        }

        public async Task<GradeDto> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            var gradeEntity = _mapper.Map<Grade>(request);
            if (gradeEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            await _gradeRepo.UpdateAsync(gradeEntity.EntityId, gradeEntity);
            var gradeResponse = _mapper.Map<GradeDto>(gradeEntity);
            return gradeResponse;
        }

        public async Task<GradeDto> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            var grade = await _gradeRepo.GetByIdAsync(request.EntityId);
            if (grade != null)
            {
                await _gradeRepo.DeleteAsync(grade);
            }

            return new GradeDto();
        }
    }
}
