using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (_, _, _, _) => true;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(configurePolicy =>
                {
                    configurePolicy.AllowAnyOrigin();
                });
            });
            builder.Services.AddControllers();

            // configure http client factory

            builder.Services.AddHttpClient("OrderService", client =>
            {
                client.BaseAddress = new Uri("https://localhost:32812/api/");
            });
            builder.Services.AddHttpClient("UserService", client =>
            {
                client.BaseAddress = new Uri("https://localhost:32811/api/");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
