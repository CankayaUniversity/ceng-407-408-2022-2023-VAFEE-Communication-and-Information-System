using Api.Application;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using WebApi.Hubs;


// todo 1) Jwt Authentication ekle. (program.cs i�erisinde eklendi, servislerde eklenmesi gerekiyor) (esat)
// todo 2) Resimleri azure'da saklamak i�in servisleri ekle. 
// todo 3) Kullan�c� Profil Y�netimi. (esat)
// todo 4) Mesajlar dbde tutulma �ekli.
// todo 5) Repository pattern ya da �zel servisler


// Ekstralar =>
// Response classlar� => uygun hata mesajlar� d�nd�rmek i�in �zel classlar (feyyaz)




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


builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});


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
        ClockSkew = TimeSpan.Zero,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),

    };


});


builder.Services.AddCors(x => x.AddPolicy("TrustedClients", p =>
{
    p.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:5173");
}));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("TrustedClients");
//app.UseAuthentication();
app.MapHub<UsersHub>("/Hubs/UsersHub");
app.UseAuthorization();
app.MapControllers();
app.Run();
