using Quartz.Impl;
using Quartz.Spi;
using Quartz;
using GithubRepositories.Infra.Quartz;
using GithubRepositories.API.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Quartz
builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddSingleton<QuartzJobRunner>();
builder.Services.AddHostedService<QuartzHostedService>();


var cron1min = "0 0/1 * 1/1 * ? *";
builder.Services.AddScoped<JobGithub>();
builder.Services.AddSingleton(new JobSchedule(jobType: typeof(JobGithub), cronExpression: cron1min));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
