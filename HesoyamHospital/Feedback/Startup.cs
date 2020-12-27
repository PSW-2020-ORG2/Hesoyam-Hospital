using Authentication.Model.FeedbackModel;
using Authentication.Model.ScheduleModel;
using Authentication.Model.UserModel;
using Feedbacks.Repository;
using Feedbacks.Repository.SQLRepository.Base;
using Feedbacks.Service;
using Feedbacks.Service.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Feedbacks
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
            services.AddSingleton<IFeedbackService, FeedbackService>(service => new FeedbackService(new FeedbackRepository(new SQLStream<Feedback>())));
            services.AddSingleton<ISurveyService, SurveyService>(service => new SurveyService(new SurveyRepository(new SQLStream<Survey>())));
            services.AddSingleton<IDoctorService, DoctorService>(service => new DoctorService(new DoctorRepository(new SQLStream<Doctor>())));
            services.AddSingleton<IPatientService, PatientService>(service => new PatientService(new PatientRepository(new SQLStream<Patient>())));
            services.AddSingleton<IAppointmentService, AppointmentService>(service => new AppointmentService(new AppointmentRepository(new SQLStream<Appointment>())));
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
