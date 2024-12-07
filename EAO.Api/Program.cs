using EAO.BL.Services;
using EAO.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RayaCX (Eao) Api",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Email = "App-Consaltant@Rayacx.com",
            Name = "RayaCX Development team",
            Url = new Uri("https://api-Eao.rayacx.com"),
        },
        License = new OpenApiLicense
        {
            Name = "Microsoft License",
            Url = new Uri("https://api-Eao.rayacx.com")
        },
        TermsOfService = new Uri("https://api-Eao.rayacx.com")
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
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
                                                },
                                                Name = "Bearer",
                                                In = ParameterLocation.Header
                                            },
                                            new List<string>()
                                        }
                                    });
});


//Add Sql Server Connection
builder.Services.AddDbContext<EaoNsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionSqlServer")));



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false // you dont want to validate lifetime 
                                 //ValidateIssuer = true,
                                 //ValidateAudience = true,
                                 //ValidAudience = Configuration["JWT:ValidAudience"],
                                 //ValidIssuer = Configuration["JWT:ValidIssuer"],
                                 //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
    };
});

//Regester Services
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<QuestionService>();
builder.Services.AddScoped<GovernorateService>();
builder.Services.AddScoped<AreaService>();
builder.Services.AddScoped<IncidentService>();
builder.Services.AddScoped<CallerService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<RequestService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
