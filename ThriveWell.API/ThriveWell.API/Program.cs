using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using ThriveWell.API.Data;
using ThriveWell.API.Endpoint;
using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.Repositories;
using ThriveWell.API.Respositories;
using ThriveWell.API.Sevices;

var builder = WebApplication.CreateBuilder(args);

// allows passing datetimes without time zone data
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<ThriveWellDbContext>(builder.Configuration["ThriveWellDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options => { options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

// Add services to the container.
builder.Services.AddScoped<IThriveWellDailyJournalService, ThriveWellDailyJournalService>();
builder.Services.AddScoped<IThriveWellDailyJournalRepository, ThriveWellDailyJournalRepository>();
builder.Services.AddScoped<IThriveWellSymptomLogService, ThriveWellSymptomLogService>();
builder.Services.AddScoped<IThriveWellSymptomLogRepository, ThriveWellSymptomLogRepository>();
builder.Services.AddScoped<IThriveWellSymptomService, ThriveWellSymptomService>();
builder.Services.AddScoped<IThriveWellSymptomRepository, ThriveWellSymptomRepository>();
builder.Services.AddScoped<IThriveWellTriggerService, ThriveWellTriggerService>();
builder.Services.AddScoped<IThriveWellTriggerRepository, ThriveWellTriggerRepository>();
builder.Services.AddScoped<IThriveWellSymptomTriggerService, ThriveWellSymptomTriggerService>();
builder.Services.AddScoped<IThriveWellSymptomTriggerRepository, ThriveWellSymptomTriggerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.MapDailyJournalEndpoints();
app.MapSymptomLogEndpoints();
app.MapSymptomEndpoints();
app.MapTriggerEndpoints();
app.MapSymptomTriggerEndpoints();

app.Run();