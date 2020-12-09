using Backend.Model.PatientModel;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using Backend.Repository.MySQLRepository.UsersRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Documents.Service;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
using WebApplication.Authentication;
using WebApplication.Scheduling.Service;
using Backend.Model.UserModel;
using WebApplication.Appointments.Service;
using Backend.Repository.MySQLRepository.MedicalRepository;

namespace WebApplication
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
            services.AddSingleton<IDocumentService, DocumentService>(service => new DocumentService(new PrescriptionRepository(new MySQLStream<Prescription>(), new LongSequencer()), new ReportRepository(new MySQLStream<Report>(), new LongSequencer())));
            services.AddSingleton<IAppointmentService, AppointmentService>(services => new AppointmentService(new PatientRepository(new MySQLStream<Patient>(), new LongSequencer(), new UserRepository(new MySQLStream<User>(), new LongSequencer())), new AppointmentRepository(new MySQLStream<Appointment>(), new LongSequencer()), new CancellationRepository(new MySQLStream<Cancellation>(), new LongSequencer())));
            services.AddSingleton<ISendEmail, SendEmail>();
            services.AddSingleton<IAppointmentSchedulingService, AppointmentSchedulingService>(service=> new AppointmentSchedulingService(new DoctorRepository(new MySQLStream<Doctor>(), new LongSequencer(), new UserRepository(new MySQLStream<User>(), new LongSequencer())), new AppointmentRepository(new MySQLStream<Appointment>(), new LongSequencer())));


            services.AddMvc().AddJsonOptions(options =>
                    options.JsonSerializerOptions.MaxDepth = 10);
            services.AddControllers();
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddControllers().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Resources")),
                RequestPath = "/Resources"
            });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
