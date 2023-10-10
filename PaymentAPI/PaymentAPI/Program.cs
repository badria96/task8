using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;



internal class Program
{

    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<PaymentDetailContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(options =>
        options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());
        app.UseAuthentication();
        app.MapControllers();
        app.Run();
    }
}

