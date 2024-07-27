using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.ComponentModel;
using DispenarioMedBCK.Models;
using DispenarioMedBCK.Repositorio;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<DispensarioContext>(opcion => opcion.UseSqlServer("name=DefaultConnection"));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin
        ().AllowAnyHeader().AllowAnyMethod()));

        builder.Services.AddScoped<IRepositorioUbicaciones, RepositorioUbicaciones>();
        builder.Services.AddScoped<IRepositorioEspecialidad, RepositorioEspecialidad>();
        builder.Services.AddScoped<IRepositorioAgenda, RepositorioAgenda>();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {


            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
       
        
        var app = builder.Build();
        app.UseCors("AllowWebApp");
        app.UseRouting();

        app.MapControllers();
        app.UseHttpsRedirection();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}