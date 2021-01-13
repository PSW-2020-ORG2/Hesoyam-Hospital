using Appointments.Model;
using Appointments.Repository;
using Appointments.Repository.SQLRepository.Base;
using Appointments.Service;
using Appointments.Service.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Appointments
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*")
                                      .SetIsOriginAllowedToAllowWildcardSubdomains()
                                      .AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            services.AddSingleton<IAppointmentService, AppointmentService>(service => new AppointmentService(new AppointmentRepository(new SQLStream<Appointment>()), new CancellationRepository(new SQLStream<Cancellation>())));
            services.AddSingleton<IAppointmentSchedulingService, AppointmentSchedulingService>(service => new AppointmentSchedulingService(new AppointmentRepository(new SQLStream<Appointment>()), new TimeTableRepository(new SQLStream<TimeTable>())));
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpClient();

            if (isPostgres())
            {
                services.AddDbContext<MyDbContext>(options =>
                    options.UseNpgsql(GetConnectionString()));
            }
        }
        private string GetConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            Console.WriteLine("Server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString"));
            return "Server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString");
        }
        private bool isPostgres()
        {
            return Environment.GetEnvironmentVariable("USES_POSTGRES") == "TRUE";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (isPostgres())
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<MyDbContext>();

                    RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
                    if (isPostgres())
                        databaseCreator.CreateTables();
                }
            }
        }
    }
}
