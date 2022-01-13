
using CapgeminiDDD.Infrastructure.Repository;
using Indra.Application.Services.Configuration.Models;
using Indra.Infrastructure.Persistence;
using Indra.Infrastructure.Repository;
using Indra.Infrastructure.Repository.Implementations;
using Indra.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Indra.Application.Services.Configuration
{
    public class DIConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public DIConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void ConfigureServices()
        {
            _services.AddDbContext<IndraDbContext>();
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
            //_services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            _services.AddScoped<IStudentRepository, StudentRepository>();
            _services.AddScoped<IUserRepository, UserRepository>();

            AddJWTTokenServices();

        }

        public void AddJWTTokenServices()
        {
            var bindJwtSettings = new JwtSettings();
            _configuration.Bind("JsonWebTokenKeys", bindJwtSettings);

            _services.AddSingleton(bindJwtSettings);

            _services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
                    ValidateIssuer = bindJwtSettings.ValidateIssuer,
                    ValidIssuer = bindJwtSettings.ValidIssuer,
                    ValidateAudience = bindJwtSettings.ValidateAudience,
                    ValidAudience = bindJwtSettings.ValidAudience,
                    RequireExpirationTime = bindJwtSettings.RequireExpirationTime,
                    ValidateLifetime = bindJwtSettings.RequireExpirationTime,
                    ClockSkew = TimeSpan.FromDays(1),
                };
            });
        }
    }
}
