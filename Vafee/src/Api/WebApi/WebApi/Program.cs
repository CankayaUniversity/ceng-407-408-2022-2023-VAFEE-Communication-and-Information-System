using Api.Application;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var trustedAddresses = new string[] { "", "" };

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Db, authentication*, signalr*, (usermanager, rolemanager, signinmanager), vue ve flutter uygulamasý için cors*
// * olanlarýn ayarlarý yapýldýktan sonra uygun yerlere ekle. (app.UseCors() ...)
builder.Services.RegisterInfrastructureServices(); // Db,
builder.Services.RegisterApplicationServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
