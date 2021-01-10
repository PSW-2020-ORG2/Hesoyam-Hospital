using Authentication.Model;
using Authentication.Repository;
using Authentication.Repository.Abstract;
using Authentication.Repository.FileRepository;
using Authentication.Repository.SQLRepository.Base;
using Authentication.Service;
using Authentication.Service.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Authentication
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
            services.AddSingleton<ISendEmailService, SendEmailService>(service => new SendEmailService());
            services.AddSingleton<IImageRepository, ImageRepository>(repository => new ImageRepository());
            services.AddSingleton<IPatientService, PatientService>(service => new PatientService(new PatientRepository(new SQLStream<Patient>()), new MedicalRecordRepository(new SQLStream<MedicalRecord>()), new DoctorRepository(new SQLStream<Doctor>())));
            services.AddSingleton<IMedicalRecordService, MedicalRecordService>(service => new MedicalRecordService(new MedicalRecordRepository(new SQLStream<MedicalRecord>())));
            services.AddSingleton<IDoctorService, DoctorService>(service => new DoctorService(new DoctorRepository(new SQLStream<Doctor>())));
            services.AddSingleton<ILoginService, LoginService>(service => new LoginService(new PatientRepository(new SQLStream<Patient>()), new AdminRepository(new SQLStream<SystemAdmin>())));
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Resources")),
                RequestPath = "/Resources"
            });

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
