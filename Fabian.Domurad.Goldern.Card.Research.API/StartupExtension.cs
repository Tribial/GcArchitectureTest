using System.Security.Claims;
using System.Text;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.MapperProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Fabian.Domurad.Golden.Card.Research.API
{
    public static class StartupExtension
    {
        public static void AddMapperExt(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(UserProfile), 
                typeof(LocalizationProfile), 
                typeof(FloorProfile),
                typeof(DeskProfile), 
                typeof(DeskBookingProfile),
                typeof(CommonProfile));
        }

        public static void AddSwaggerExt(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.1", new OpenApiInfo { Title = "GC Research API", Version = "v0.1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        public static void UseSwaggerExt(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(cfg =>
            {
                cfg.SwaggerEndpoint("v0.1/swagger.json", "GC Research API");
            });
        }

        public static void AddJwtExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration[SettingsConst.JwtIssuerRoot],
                        ValidAudience = configuration[SettingsConst.JwtIssuerRoot],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[SettingsConst.JwtKeyRoot])),
                        RoleClaimType = ClaimTypes.Role,
                    };
                });
        }
    }
}
