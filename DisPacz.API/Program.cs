using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DisPacz.API.Features.Workers.Providers;
using DisPacz.API.Features.Workers.Services;
using DisPacz.API.Features.Jobs.Services;
using DisPacz.API.Features.Jobs.Providers;
using DisPacz.API.Features.Clients.Services;
using DisPacz.API.Features.Clients.Providers;
using DisPacz.API.Features.Locations.Services;
using DisPacz.API.Features.Locations.Providers;

namespace DisPacz.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<Models.Data.ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<IWorkerProvider, WorkerProvider>();
            builder.Services.AddScoped<IWorkerService, WorkerService>();
            builder.Services.AddScoped<IJobProvider, JobProvider>();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IClientProvider, ClientProvider>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ILocationProvider, LocationProvider>();
            builder.Services.AddScoped<ILocationService, LocationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
