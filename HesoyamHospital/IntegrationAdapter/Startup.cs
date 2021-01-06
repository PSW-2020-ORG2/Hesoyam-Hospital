using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.PatientModel;
using Backend.Model.PharmacyModel;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Repository.MySQLRepository.MiscRepository;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using IntegrationAdapter.SFTPServiceSupport;
using IntegrationAdapter.UrgentProcurement.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace IntegrationAdapter
{
    public class Startup
    {

        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<ReportTimerService>();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrgin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());
            services.AddControllers();
            services.AddSingleton<IUrgentMedicineProcurementService, UrgentMedicineProcurementService>(service =>
            new UrgentMedicineProcurementService(new UrgentMedicineProcurementRepository(new MySQLStream<UrgentMedicineProcurement>(), new LongSequencer()),
            new RegisteredPharmacyRepository(new MySQLStream<RegisteredPharmacy>(), new LongSequencer()),
            new MedicineRepository(new MySQLStream<Medicine>(), new LongSequencer()), _env));
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
