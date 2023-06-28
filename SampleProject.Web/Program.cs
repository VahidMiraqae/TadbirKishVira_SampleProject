using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SampleProject.Application;
using SampleProject.Core;
using SampleProject.Infrastructure.Data;
using SampleProject.Web.DTOs;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-Q97F0AB; Database=TadbirKishVira.SampleProject;Trusted_Connection=True;Encrypt=False");
});

var mapperConfig = new MapperConfiguration(config =>
{
    config.CreateMap<RequestDto, Request>();
    config.CreateMap<CoverageRequestDto, RequestCoverage>();
    config.CreateMap<CoverageType, CoverageTypeDto>();
    config.CreateMap<RequestDto,RequestProcessedDto>();

});

builder.Services.AddScoped<IInsuranceService, InsuranceService>();

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
