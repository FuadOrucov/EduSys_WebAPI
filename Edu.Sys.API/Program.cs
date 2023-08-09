using Microsoft.EntityFrameworkCore;
using EeduSys.Repository;
using System.Reflection;
using EduSys.Core.UnitOfWork;
using EeduSys.Repository.UnitOfWork;
using EduSys.Core.Repositories;
using EeduSys.Repository.Repositories;
using EduSys.Service.Mapping;
using EduSys.Core.Services;
using EduSys.Service.Services;
using EduSys.Repository.Repositories;
using FluentValidation.AspNetCore;
using EduSys.Service.Validations;
using Edu.Sys.API.Filters;
using Microsoft.AspNetCore.Mvc;
using Edu.Sys.API.Middlewares;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Edu.Sys.API.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddFluentValidation(o => o.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFiltreAtribute()));
builder.Services.Configure<ApiBehaviorOptions>(option => option.SuppressModelStateInvalidFilter = true);


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
    
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder=> containerBuilder.RegisterModule(new RepoServiceModule()));

 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();
