using Api.Application;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var trustedClientAddresses = new string[] { "", "" };

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Db, authentication*, signalr*, (usermanager, rolemanager, signinmanager), vue ve flutter uygulamas� i�in cors*,mapper (mapster)
// * olanlar�n ayarlar� yap�ld�ktan sonra uygun yerlere ekle. (app.UseCors() ...)

builder.Services.RegisterInfrastructureServices(); // Db, (usermanager, rolemanager, signinmanager)
builder.Services.RegisterApplicationServices(); // mapper



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        //todo Jwt validation ayarlar�n� burada yap.
        // Jwt'nin ge�erli olup olmad��� kontrol edilirken hangi kurallara bak�laca��n� burada belirle

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),

    };


});


builder.Services.AddCors(x => x.AddPolicy("TrustedClients", p =>
{
    p.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins(trustedClientAddresses);
}));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors("TrustedClients");
//app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
