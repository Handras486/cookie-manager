using CookieManager.Data;
using CookieManager.WebAPI.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using Serilog;
using CookieManager.WebAPI.Middlewares;
using CookieManager.Service;
using CookieManager.Service.Interfaces;
using CookieManager.Repository.Interfaces;
using CookieManager.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;
using CookieManager.WebAPI.Extensions;
using System.Runtime.CompilerServices;

namespace CookieManager.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/CookieManager_Log.txt", rollingInterval: RollingInterval.Day)
                .MinimumLevel.Warning()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddApplicationServices(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
                RequestPath = "/Images"
            });

            app.MapControllers();

            app.Run();
        }
    }
}