using DotNetCore8AuthDemo;
using DotNetCore8AuthDemo.Controllers.Services;
using DotNetCore8AuthDemo.Data;
using DotNetCore8AuthDemo.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add authentification
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

//Add authorization

//configure dbContext

builder.Services.AddDbContext<AppDbContext>(option => option.UseNpgsql("Server=127.0.0.1; Port=5432; Database=DemoDatabase;User Id=postgres;Password=admin123"));
builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

//builder.Services.RegisterAllIoc();
var app = builder.Build();

//Map identityUser
app.MapIdentityApi<AppUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Manager" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
    
}
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    string email = "admin1@gmail.com";
    string password = "@Aa123123";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new AppUser();
        user.UserName = email;
        user.Email = email;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }


}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

   

    string email = "admin@gmail.com";
    string password = "@Aa123123";

    var identityUser = await userManager.FindByEmailAsync(email);

    if (identityUser != null)
    {
        var claim = new Claim("add product","true");
        var result = await userManager.AddClaimAsync(identityUser, claim);
    }


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
