using Mantel.Common.Startup.Swagger;
using Mantel.Course_Service.Application.Features.Courses.Queries;
using Mantel.Course_Service.Application.Mapping;
using Mantel.Course_Service.Domain.Interfaces;
using Mantel.Course_Service.Infrastructure.Data;
using Mantel.Course_Service.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CourseDbContext>(options =>
{
    options.UseCosmos(
        builder.Configuration["CosmosDb:AccountEndpoint"],
        builder.Configuration["CosmosDb:AccountKey"],
        databaseName: "CourseDb"
    );
});

builder.Services.AddControllers();
builder.RegisterSwagger();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.RegisterServicesFromAssembly(typeof(GetAllCoursesQuery).Assembly);
});

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CourseDbContext>();
    await db.Database.EnsureCreatedAsync();
}

app.MapControllers();

app.AddSwaggerUI();

app.Run();
