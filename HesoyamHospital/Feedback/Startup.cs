using Feedbacks.Repository;
using Feedbacks.Repository.SQLRepository.Base;
using Feedbacks.Service;
using Feedbacks.Service.Abstract;
using Feedbacks.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
                    if (isPostgres()){
                        databaseCreator.CreateTables();
                        Console.WriteLine("FEEDBACK-----------CREATING TABLES");
                    }
                }
            }
        }
    }
}
