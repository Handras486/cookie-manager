using CookieManager.Data;
using CookieManager.Repository.Interfaces;
using CookieManager.Repository;
using CookieManager.Service.Interfaces;
using CookieManager.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using CookieManager.WebAPI.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CookieManager.WebAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices( this IServiceCollection services, IConfiguration config)
        {

            // SWAGGER
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Cookie Manager API", Version = "v1" });
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            },
                            Scheme = "Oauth2",
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            //DATABASES
            services.AddDbContext<CookieManagerDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("CookieManagerConnectionString"),
                    b => b.MigrationsAssembly("CookieManager.Data"));
            });
            services.AddDbContext<CookieManagerAuthDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("CookieManagerAuthConnectionString"),
                    b => b.MigrationsAssembly("CookieManager.Data"));
            });

            // DEPENDENCY INJECTION
            services.AddScoped<ICookieService, CookieService>();
            services.AddScoped<ICookieRepository, SQLCookieRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageRepository, LocalImageRepository>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IActivityRepository, SQLActivityRepository>();


            //AUTOMAPPER
            services.AddAutoMapper(typeof(AutoMapperProfiles));


            //SECURITY

            //CORS
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            //AUTHENTICATION
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["JWT:Issuer"],
                    ValidAudience = config["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]))
                });


            //AUTHORIZATION
            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("CookieManager")
                .AddEntityFrameworkStores<CookieManagerAuthDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            return services;
        }
    }
}
