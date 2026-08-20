using FluentValidation;
using GameTest.Api.Middleware;
using GameTest.Api.Services;
using GameTest.Application.Common.Behaviors;
using GameTest.Application.Features.Runs.Commands.SaveRun;
using GameTest.Application.Interfaces;
using GameTest.Infrastructure;
using GameTest.Infrastructure.Authentication;
using GameTest.Infrastructure.Data.Seeders;
using GameTest.Infrastructure.Factories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not found");

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(IAppDbContext).Assembly);
});

builder.Services.AddValidatorsFromAssembly(
    typeof(SaveRunCommandValidator).Assembly);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddScoped<IArenaFactory, ArenaFactory>();
builder.Services.AddScoped<ICatFactory, CatFactory>();
builder.Services.AddScoped<IEnemyFactory, EnemyFactory>();
builder.Services.AddScoped<IItemFactory, ItemFactory>();
builder.Services.AddScoped<IPlayerProgressFactory, PlayerProgressFactory>();
builder.Services.AddScoped<IUnitFactory, UnitFactory>();
builder.Services.AddScoped<IWeaponFactory, WeaponFactory>();

builder.Services.AddScoped<ArenaSeeder>();
builder.Services.AddScoped<CatSeeder>();
builder.Services.AddScoped<CatStatSeeder>();
builder.Services.AddScoped<EnemySeeder>();
builder.Services.AddScoped<EnemyStatSeeder>();
builder.Services.AddScoped<ItemSeeder>();
builder.Services.AddScoped<UnitSeeder>();
builder.Services.AddScoped<UnitStatSeeder>();
builder.Services.AddScoped<WeaponSeeder>();
builder.Services.AddScoped<WeaponStatSeeder>();
builder.Services.AddScoped<DatabaseSeeder>();

var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("Jwt:Key not found");

var jwtIssuer = builder.Configuration["Jwt:Issuer"]
    ?? throw new InvalidOperationException("Jwt:Issuer not found");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GameTest API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IAppDbContext>();

    dbContext.Database.Migrate();

    var databaseSeeder = scope.ServiceProvider
        .GetRequiredService<DatabaseSeeder>();

    await databaseSeeder.SeedAsync(CancellationToken.None);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
