using Dev.UAA3.Backend.ApplicationCore.Interfaces;
using Dev.UAA3.Backend.ApplicationCore.Services;
using Dev.UAA3.Backend.Domain.Services;
using Dev.UAA3.Backend.Infrastructure.Database;
using Dev.UAA3.Backend.Infrastructure.Database.Repositories;
using Dev.UAA3.Backend.Presentation.WebAPI.Configs;
using Dev.UAA3.Backend.Presentation.WebAPI.ExceptionHanders;
using Dev.UAA3.Backend.Presentation.WebAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<TokenTool>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddControllers();

builder.Services.AddExceptionHandler<MemberExceptionHandler>();
builder.Services.AddExceptionHandler<ReservationExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    byte[] secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"]!);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = builder.Configuration["Token:Issuer"],
                        ValidAudience = builder.Configuration["Token:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey),

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                    };
                });

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
