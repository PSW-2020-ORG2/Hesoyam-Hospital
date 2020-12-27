using Authentication.Model.ScheduleModel;
using Authentication.Model.UserModel;
using Appointments.Repository;
using Appointments.Repository.SQLRepository.Base;
using Appointments.Service;
using Appointments.Service.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddSingleton<IAppointmentService, AppointmentService>(service => new AppointmentService(new PatientRepository(new SQLStream<Patient>()), new AppointmentRepository(new SQLStream<Appointment>()), new CancellationRepository(new SQLStream<Cancellation>())));
            services.AddSingleton<IAppointmentSchedulingService, AppointmentSchedulingService>(service => new AppointmentSchedulingService(new DoctorRepository(new SQLStream<Doctor>()), new AppointmentRepository(new SQLStream<Appointment>())));
            services.AddSingleton<IPatientService, PatientService>(service => new PatientService(new PatientRepository(new SQLStream<Patient>())));
            services.AddSingleton<IDoctorService, DoctorService>(service => new DoctorService(new DoctorRepository(new SQLStream<Doctor>())));
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
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
