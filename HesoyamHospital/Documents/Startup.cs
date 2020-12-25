using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Documents.Repository;
using Documents.Repository.SQLRepository.Base;
using Documents.Service;
using Documents.Service.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Documents
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
            services.AddSingleton<IDocumentService, DocumentService>(service => new DocumentService(new PrescriptionRepository(new SQLStream<Prescription>()), new ReportRepository(new SQLStream<Report>())));
            services.AddSingleton<IMedicalRecordService, MedicalRecordService>(service => new MedicalRecordService(new MedicalRecordRepository(new SQLStream<MedicalRecord>())));
            services.AddSingleton<IDoctorService, DoctorService>(service => new DoctorService(new DoctorRepository(new SQLStream<Doctor>())));
            services.AddSingleton<IPatientService, PatientService>(service => new PatientService(new PatientRepository(new SQLStream<Patient>()), new MedicalRecordRepository(new SQLStream<MedicalRecord>()), new DoctorRepository(new SQLStream<Doctor>())));
            services.AddControllers();
            //services.AddControllers().AddNewtonsoftJson();
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
        }
    }
}
