using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phones.Infrastrructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString")));


var app = builder.Build();
app.UseRouting();
app.UseEndpoints(x => x.MapControllers());
app.Run();