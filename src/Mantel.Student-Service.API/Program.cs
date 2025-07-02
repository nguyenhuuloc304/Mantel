using Mantel.Common.Filters;
using Mantel.Common.Startup.Swagger;
using Mantel.Student_Service.Application.Features.Students.Queries;
using Mantel.Student_Service.Application.Mapping;
using Mantel.Student_Service.Domain.Interfaces;
using Mantel.Student_Service.Infrastructure.Data;
using Mantel.Student_Service.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.RegisterSwagger();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.RegisterServicesFromAssembly(typeof(GetAllStudentsQuery).Assembly);
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

app.MapControllers();

app.AddSwaggerUI();

app.Run();
