using Mantel.Common.Filters;
using Mantel.Common.Startup.Swagger;
using Mantel.Grade_Service.Application.Features.Grades.Queries;
using Mantel.Grade_Service.Application.Mapping;
using Mantel.Grade_Service.Domain.Interfaces;
using Mantel.Grade_Service.Infrastructure.Data;
using Mantel.Grade_Service.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GradeDbContext>(options =>
{
    options.UseCosmos(
        builder.Configuration["CosmosDb:AccountEndpoint"],
        builder.Configuration["CosmosDb:AccountKey"],
        databaseName: "GradeDb"
    );
});

builder.Services.AddControllers();
builder.RegisterSwagger();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.RegisterServicesFromAssembly(typeof(GetAllGradesQuery).Assembly);
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GradeDbContext>();
    await db.Database.EnsureCreatedAsync();
}

app.MapControllers();

app.AddSwaggerUI();

app.Run();
