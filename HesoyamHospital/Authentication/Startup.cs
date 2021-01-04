using Authentication.Model;
using Authentication.Repository;
using Authentication.Repository.Abstract;
using Authentication.Repository.FileRepository;
using Authentication.Repository.SQLRepository.Base;
using Authentication.Service;
using Authentication.Service.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
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
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
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
        }
    }
}
