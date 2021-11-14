using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.JobOfferRepositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.JobOfferServices;
using jobagapi.Persistence.Contexts;
using jobagapi.Persistence.Repositories;
using jobagapi.Persistence.Repositories.JobOfferPersistence;
using jobagapi.Services;
using jobagapi.Services.JobOfferServicesImpl;
using Microsoft.EntityFrameworkCore;

namespace jobagapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("jobag-api-in-memory");
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jobag API", Version = "v1" });
            });

            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<IJobOfferService, JobOfferService>();

            services.AddScoped<IMailMessageRepository, MailMessageRepository>();
            services.AddScoped<IMailiMessageService, MailMessageService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Para configurar autoMapper
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jobag API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
