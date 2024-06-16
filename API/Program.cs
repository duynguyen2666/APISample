using API.Database;
using API.Middlewares;
using API.Services.Abstractions;
using API.Services;
using API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("Main");

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddLogging(logBuilder =>
        {
            logBuilder.AddDebug();
            logBuilder.AddConsole();
        });


        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;  // Optional
            options.DefaultApiVersion = new ApiVersion(1, 0);   // Optional
            options.ReportApiVersions = true;
            // Choose your versioning strategy:
            // options.ApiVersionReader = new QueryStringApiVersionReader("api-version"); 
            options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            // options.ApiVersionReader = new MediaTypeApiVersionReader(); 
        });

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddDbContext<APIDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddSingleton<ITokenService, TokenService>();
        builder.Services.AddSingleton<IHashingService, Md5HashingService>();
        builder.Services.AddTransient<DbInitializer>();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });

        var app = builder.Build();
        app.Lifetime.ApplicationStarted.Register(() =>
        {
            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetService<DbInitializer>()?.Initialize();
            }
        });

        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}