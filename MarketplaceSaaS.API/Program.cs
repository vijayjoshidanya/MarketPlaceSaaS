using AutoMapper;
using MarketplaceSaaS.BLL.MappingProfiles;
using MarketplaceSaaS.BLL.Services;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MarketplaceSaaS.BLL.Validators;
using MarketplaceSaaS.API.MiddleWares;
using Serilog;
using System.Reflection;
using MarketplaceSaaS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MarketplaceSaaS.BLL.Interfaces;
using MarketplaceSaaS.DAL.UnitOfWork;
using MarketplaceSaaS.Domain.Repositories;
using MarketplaceSaaS.DAL.Data;
using MarketplaceSaaS.DAL.Respositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext here:
builder.Services.AddDbContext<MarketplaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MarketplaceDbContext>()
    .AddDefaultTokenProviders();

// Add Authentication with JWT Bearer
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "JwtBearer";
//    options.DefaultChallengeScheme = "JwtBearer";
//})
//.AddJwtBearer("JwtBearer", options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(
//System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//});


// Program.cs: Registers your dependencies in the DI container.
// Tells .NET which concrete class to use for each interface.
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IVendorService, VendorService>();

//builder.Services.AddAutoMapper(cfg => { cfg.AddProfile(new VendorProfile()); }, Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(typeof(VendorProfile));



builder.Services.AddValidatorsFromAssemblyContaining<VendorRequestValidator>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
