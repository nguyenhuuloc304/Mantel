using Mantel.Common.Startup.Swagger;
//using Mantel.Grade_Service.Application.Features.Students.Queries;
//using Mantel.Grade_Service.Application.Mapping;
using Mantel.Grade_Service.Domain.Interfaces;
using Mantel.Grade_Service.Infrastructure.Data;
using Mantel.Grade_Service.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.RegisterSwagger();

app.MapGet("/", () => "Hello World!");

app.Run();
