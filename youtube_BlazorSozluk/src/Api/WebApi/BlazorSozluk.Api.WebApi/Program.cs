using BlazorSozluk.Api.Application.Extensions;
using BlazorSozluk.Api.Infrastructure.Persistence.Extensions;
using BlazorSozluk.Api.WebApi.Infrastructure.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(/*opt => opt.Filters.Add<BlazorSozluk.Api.WebApi.ValidateModelStateFilter>()*/)
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    })
    .AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.AddApplicationRegistration();
builder.Services.AddInfrastructureRegistration(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//development k�sm�nda hatalar� g�rmek i�in
app.ConfigureExceptionHandling(app.Environment.IsDevelopment());
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();