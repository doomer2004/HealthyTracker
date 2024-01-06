using System.Net;
using System.Net.Mail;
using System.Text;
using FluentEmail.MailKitSmtp;
using HealthyTracker.BLL.Extensions;
using HealthyTracker.BLL.Services.Auth.Auth;
using HealthyTracker.BLL.Services.Auth.Interfaces;
using HealthyTracker.BLL.Services.DailyService.Interfaces;
using HealthyTracker.BLL.Services.DailyService.Services;
using HealthyTracker.BLL.Services.MealService.Interfaces;
using HealthyTracker.BLL.Services.MealService.Services;
using HealthyTracker.BLL.Services.NutritionService.Interfaces;
using HealthyTracker.BLL.Services.NutritionService.Services;
using HealthyTracker.BLL.Services.ProductService.Interfaces;
using HealthyTracker.BLL.Services.ProductService.Services;
using HealthyTracker.BLL.Services.UserServices.Services;
using HealthyTracker.Client.Nutrition;
using HealthyTracker.Common.Models.Configs;
using HealthyTracker.DAL.Contexts;
using HealthyTracker.DAL.Entities;
using HealthyTracker.DAL.Repositories;
using HealthyTracker.DAL.Repositories.Interfaces;
using HealthyTracker.Email.Services;
using HealthyTracker.Email.Services.Interfaces;
using HealthyTracker.Extensions;
using HealthyTracker.Mapping.Profiles;
using HealthyTracker.Validation.Auth;
using HealthyTracker.Validation.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("NutritionsClient");
builder.Services.AddScoped<INutritionsClient, NutritionsClient>();

var appDataConfig = new AppDataConfig();
var jwtConfig = new JwtConfig();
var emailConfig = new EmailConfig();
var googleConfig = new GoogleConfig();
var nutritionsConfig = new NutritionsConfig();
//var emailSettings = builder.Configuration.GetSection("EmailConfig");

builder.Services.AddConfigs(builder.Configuration, opt =>
    opt.AddConfig<AppDataConfig>(out appDataConfig, configureOptions: config =>
        {
            config.AppDataPath = config.AppDataPath.ToAbsolutePath();
            config.WebRootPath = builder.Environment.WebRootPath;
        })
        .AddConfig<JwtConfig>(out jwtConfig)
        .AddConfig<EmailConfig>(out emailConfig,
            configureOptions: config => config.TemplatesPath = config.TemplatesPath.ToAbsolutePath())
        .AddConfig<AuthConfig>()
        .AddConfig<GoogleConfig>(out googleConfig)
        .AddConfig<NutritionsConfig>(out nutritionsConfig)
        .AddConfig<CallbackUrisConfig>());
        
//DbContext
var dbContextLoggerFactory = LoggerFactory.Create(cfg => cfg.AddConsole());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseLoggerFactory(dbContextLoggerFactory));

//Repositories
builder.Services.AddScoped<IDailyRepository, DailyRepository>();
builder.Services.AddScoped<IUserRegistrationRepository, UserRegistrationRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<INutritionGoalRepository, NutritionGoalRepository>();


//Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailConfirmationService, EmailConfirmationService>();
builder.Services.AddScoped<IGoogleAuthService, GoogleAuthService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();
builder.Services.AddScoped<IUserRegistrationService, UserRegistrationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<INutritionGoalService, NutritionGoalService>();
builder.Services.AddScoped<IDailyService, DailyService>();
builder.Services.AddScoped<IMealService, MealService>();



//Email
var client = new SmtpClient();
client.Credentials = new NetworkCredential(emailConfig.DefaultEmail, emailConfig.Password);
client.Host = emailConfig.SmtpServer;
client.Port = 587;
client.DeliveryMethod = SmtpDeliveryMethod.Network;
client.EnableSsl = true;
client.UseDefaultCredentials = false;

builder.Services.AddFluentEmail(emailConfig.DefaultEmail)
    .AddSmtpSender(client)
    .AddRazorRenderer(emailConfig.TemplatesPath);

builder.Services.AddScoped<IEmailSender, EmailSender>();

//Utility
builder.Services.AddCors();
builder.Services.AddMemoryCache();    

//Mapper
builder.Services.AddAutoMapper(typeof(UserProfile));

//Validators
builder.Services.AddValidatorServiceFromAssemblyContaining<SignInDTOValidator>();

//Logger
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Map(
        evt => evt.Level,
        (level, wt) =>
            wt.File(
                $@"{appDataConfig.AppDataPath}\{appDataConfig.LogDirectory}\{level}-{DateTime.Today:yyyy-MM-dd}.log"))
    .CreateLogger();
builder.Logging.AddSerilog(logger, dispose: true);

//Auth
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)),
    ValidIssuer = jwtConfig.Issuer,
    ValidAudience = jwtConfig.Audience,
    ClockSkew = jwtConfig.ClockSkew
};
builder.Services.AddSingleton(tokenValidationParameters);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = tokenValidationParameters;
    });

//Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthyTracker API", Version = "v1" });

    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MigrateDatabase();

await app.ValidateConfigsAsync();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
