using BlogProject.Core.DomainModels.Models;
using BlogProject.Infrasturacture_3.Contexts;
using BlogProject.Infrasturacture_3.Repositories;
using BlogProject.Infrasturacture_3.Utilities.Logging;
using BlogProject.Infrasturacture_3.Utilities.UnitOfWork;
using BlogProject_Application_2.IRepositories;
using BlogProject_Application_2.Mappers;
using BlogProject_Application_2.Services;
using BlogProject_Application_2.Services.IServices;
using BlogProject_Application_2.Utilities.IUnitOfWork;
using BlogProject_Application_2.Utilities.Logging;
using Microsoft.AspNetCore.Identity;

namespace BlogProject_WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Mapper
            builder.Services.AddAutoMapper(typeof(Mapping));

            //Context
            builder.Services.AddDbContext<AppDbContext>();

            //Identity
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //Logger
            builder.Services.AddScoped<ILogging, Logging>();

            //UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();

            
            


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
        }
    }
}
