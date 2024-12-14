using Microsoft.EntityFrameworkCore;
using PlatformServices.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();  // Register controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("PlatformDb"));
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService v1");
    });
}

app.UseHttpsRedirection();  // Ensure HTTPS redirection is enabled

app.UseAuthorization();  // Ensure Authorization middleware is in place

app.MapControllers();  // Map your controllers

PrepDb.PrepPopulation(app);  // Seed the database

app.Run();
