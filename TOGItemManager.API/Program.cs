using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NHibernate;
using SwaggerThemes;
using TOGItemManager.Application.Seguranca;

using TOGItemManager.Application.Services.Andares;
using TOGItemManager.Application.Services.Andares.Interfaces;

using TOGItemManager.Application.Services.Auth;
using TOGItemManager.Application.Services.Auth.Interfaces;
using TOGItemManager.Application.Services.Backgrounds;
using TOGItemManager.Application.Services.Backgrounds.Interfaces;
using TOGItemManager.Application.Services.Categorias;
using TOGItemManager.Application.Services.Categorias.Interfaces;

using TOGItemManager.Application.Services.Conjuntos;
using TOGItemManager.Application.Services.Conjuntos.Interfaces;

using TOGItemManager.Application.Services.Items;
using TOGItemManager.Application.Services.Items.Interfaces;

using TOGItemManager.Application.Services.NPCs;
using TOGItemManager.Application.Services.NPCs.Interfaces;

using TOGItemManager.Application.Services.Perfis;
using TOGItemManager.Application.Services.Perfis.Interfaces;

using TOGItemManager.Application.Services.Raridades;
using TOGItemManager.Application.Services.Raridades.Interfaces;

using TOGItemManager.Application.Services.Usuarios;
using TOGItemManager.Application.Services.Usuarios.Interfaces;

using TOGItemManager.Domain.Entidades.Andares.Interfaces;
using TOGItemManager.Domain.Entidades.Backgrounds.Interfaces;
using TOGItemManager.Domain.Entidades.Categorias.Interfaces;
using TOGItemManager.Domain.Entidades.Conjuntos.Interfaces;
using TOGItemManager.Domain.Entidades.Items.Interfaces;
using TOGItemManager.Domain.Entidades.NPCs.Interfaces;
using TOGItemManager.Domain.Entidades.Perfis.Interfaces;
using TOGItemManager.Domain.Entidades.Raridades.Interfaces;
using TOGItemManager.Domain.Entidades.Usuarios.Interfaces;

using TOGItemManager.Infra.Mapping;
using TOGItemManager.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);


// =========================
// CONTROLLERS
// =========================

builder.Services.AddControllers();


// =========================
// SWAGGER
// =========================

builder.Services.AddSwaggerGen(options =>
{
    // Configuração básica
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TOG Item Manager API",
        Version = "v1"
    });

    // 🔐 Definição do JWT
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite: Bearer {seu token}"
    });

    // 🔐 Aplicar segurança globalmente
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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


// =========================
// AUTOMAPPER
// =========================

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// =========================
// CORS
// =========================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


// =========================
// SERVICES
// =========================

builder.Services.AddScoped<IRaridadeAppServico, RaridadeAppServico>();
builder.Services.AddScoped<IRaridadeRepositorio, RaridadeRepositorio>();

builder.Services.AddScoped<ICategoriaAppServico, CategoriaAppServico>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

builder.Services.AddScoped<IConjuntoAppServico, ConjuntoAppServico>();
builder.Services.AddScoped<IConjuntoRepositorio, ConjuntoRepositorio>();

builder.Services.AddScoped<INPCAppServico, NPCAppServico>();
builder.Services.AddScoped<INPCRepositorio, NPCRepositorio>();

builder.Services.AddScoped<IAndarAppServico, AndarAppServico>();
builder.Services.AddScoped<IAndarRepositorio, AndarRepositorio>();

builder.Services.AddScoped<IItemAppServico, ItemAppServico>();
builder.Services.AddScoped<IItemRepositorio, ItemRepositorio>();

builder.Services.AddScoped<IPerfilAppServico, PerfilAppServico>();
builder.Services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();

builder.Services.AddScoped<IUsuarioAppServico, UsuarioAppServico>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IBackgroundAppServico, BackgroundAppServico>();
builder.Services.AddScoped<IBackgroundRepositorio, BackgroundRepositorio>();


// =========================
// NHIBERNATE
// =========================

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var sessionFactory = Fluently.Configure()
    .Database(
        MySQLConfiguration.Standard
            .ConnectionString(connectionString)
            .ShowSql()
    )
    .Mappings(m =>
        m.FluentMappings.AddFromAssemblyOf<RaridadeMap>())
    .BuildSessionFactory();

builder.Services.AddSingleton(sessionFactory);

builder.Services.AddScoped(factory =>
{
    var factorySession = factory.GetRequiredService<ISessionFactory>();
    return factorySession.OpenSession();
});


// =========================
// JWT CONFIG
// =========================

var jwtSecret = builder.Configuration["Jwt:Secret"] 
    ?? throw new Exception("JWT Secret não configurado");

builder.Services.AddSingleton(new JwtTokenServico(jwtSecret));

var key = Encoding.ASCII.GetBytes(jwtSecret);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();


// =========================
// BUILD
// =========================

var app = builder.Build();


// =========================
// MIDDLEWARES
// =========================

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(Theme.Dracula);

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
