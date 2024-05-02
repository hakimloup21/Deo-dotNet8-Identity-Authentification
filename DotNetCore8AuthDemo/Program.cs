using DotNetCore8AuthDemo.Data;
using DotNetCore8AuthDemo.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add authentification
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

//Add authorization
builder.Services.AddAuthorizationBuilder();

//configure dbContext

builder.Services.AddDbContext<AppDbContext>(option => option.UseNpgsql("Server=127.0.0.1; Port=5432; Database=DemoDatabase;User Id=postgres;Password=admin123"));
builder.Services.AddIdentityCore<AppUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();
var app = builder.Build();

//Map identityUser
app.MapIdentityApi<AppUser>();

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
