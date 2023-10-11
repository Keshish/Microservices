using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

namespace PlatformService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(option =>
            option.UseInMemoryDatabase("InMem"));

            builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowInsomnia", builder =>
                {
                    builder.WithOrigins("http://localhost:5027")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowInsomnia");

            app.UseAuthorization();


            app.MapControllers();

            PrepDb.PrepPopulation(app);

            app.Run();
        }
    }
}