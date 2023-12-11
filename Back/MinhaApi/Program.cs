using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Service;
using MinhaApi.Service.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("UserConnection");

builder.Services.AddDbContext<UsuarioContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddSingleton<IPasswordHasherService, PasswordHasherService>();

builder.Services.AddAutoMapper(
    AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options => {

    options.AddPolicy("CorsPolicy", builder => builder

    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

