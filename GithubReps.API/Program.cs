using GithubReps.API.Jobs;
using GithubReps.Application.Services;
using GithubReps.Domain;
using GithubReps.Domain.Reps.Interface;
using GithubReps.Infra.Context;
using GithubReps.Infra.PopularReps;
using GithubReps.Infra.Quartz;
using GithubReps.Infra.UoW;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<GithubService>();
builder.Services.AddScoped<RepositoriesService>();
builder.Services.AddScoped<IPopularRepRepository, PopularRepRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Quartz
builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddSingleton<QuartzJobRunner>();
builder.Services.AddHostedService<QuartzHostedService>();


var cron1min = "0 0/1 * 1/1 * ? *";
builder.Services.AddScoped<JobGithub>();
builder.Services.AddSingleton(new JobSchedule(jobType: typeof(JobGithub), cronExpression: cron1min));

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();

