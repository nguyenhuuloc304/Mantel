using Mantel.Common.Startup.Swagger;
using Mantel.Student_Service.Application.Interfaces;
using Mantel.Student_Service.Application.Mapping;
using Mantel.Student_Service.Application.Services;
using Mantel.Student_Service.Domain.Interfaces;
using Mantel.Student_Service.Infrastructure.Data;
using Mantel.Student_Service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.RegisterSwagger();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.AddSwaggerUI();

app.Run();
