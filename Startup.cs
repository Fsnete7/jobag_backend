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
using jobagapi.Domain.Repositories.EmployerRepositories;
using jobagapi.Domain.Repositories.JobOfferRepositories;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Domain.Repositories.SubscriptionRepositories;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.EmployerServices;
using jobagapi.Domain.Services.JobOfferServices;
using jobagapi.Domain.Services.PostulantServices;
using jobagapi.Domain.Services.SubscriptionServices;
using jobagapi.Persistence.Contexts;
using jobagapi.Persistence.Repositories;
using jobagapi.Persistence.Repositories.EmployerRepositories;
using jobagapi.Persistence.Repositories.JobOfferPersistence;
using jobagapi.Persistence.Repositories.JobOfferRepositories;
using jobagapi.Persistence.Repositories.PostulantPersistence;
using jobagapi.Persistence.Repositories.SubscriptionPersistence;
using jobagapi.Persistence.Repositories.SubscriptionRepositories;
using jobagapi.Services;
using jobagapi.Services.EmployerServicesImpl;
using jobagapi.Services.JobOfferServicesImpl;
using jobagapi.Services.PostulantServicesImpl;
using jobagapi.Services.SubscriptionServicesImpl;
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
            
            services.AddCors(options =>
            {
                options.AddPolicy("Jobag",
                    builder => builder.AllowAnyOrigin());
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jobag_API", Version = "v1" });
            });
            

            //--------------- Scoped Employer Bounded Context ---------------
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<IEmployerService, EmployerService>();
            
            services.AddScoped<ICompanyProfileRepository, CompanyProfileRepository>();
            services.AddScoped<ICompanyProfileService, CompanyProfileService>();

            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<ISectorService, SectorService>();

            //--------------- Scoped Job Offer Bounded Context ---------------

            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<IJobOfferService, JobOfferService>();
            
            services.AddScoped<IPostulationRepository, PostulationRepository>();
            services.AddScoped<IPostulationService, PostulationService>();
            
            services.AddScoped<IInterviewRepository, InterviewRepository>();
            services.AddScoped<IInterviewService, InterviewService>();
            
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IContractService, ContractService>();

            
            //--------------- Scoped Subscription Bounded Context ---------------
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService,UserService>();
            
            services.AddScoped<ISubscriptionPlanRepository, SubscriptionPlanRepository>();
            services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
            
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            //--------------- Scoped Postulant Bounded Context ---------------
            services.AddScoped<IPostulantRepository, PostulantRepository>();
            services.AddScoped<IPostulantService,PostulantService>();
            
            services.AddScoped<IDegreeRepository, DegreeRepository>();
            services.AddScoped<IDegreeService,DegreeService>();
            
            services.AddScoped<IProfessionalRepository, ProfessionalProfileRepository>();
            services.AddScoped<IProfessionalProfileService,ProfessionalProfileService>();
            
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageService,LanguageService>();
            
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillService,SkillService>();
            
            services.AddScoped<IProfileSkillRepository, ProfileSkillRepository>();
            services.AddScoped<IProfileSkillService,ProfileSkillService>();
            
            services.AddScoped<IProfileDegreeRepository, ProfileDegreeRepository>();
            services.AddScoped<IProfileDegreeService,ProfileDegreeService>();
            
            services.AddScoped<IProfileLanguageRepository, ProfileLanguageRepository>();
            services.AddScoped<IProfileLanguageService,ProfileLanguageService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
           
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jobag_API v1"));
            }

            app.UseHttpsRedirection();
            
            app.UseCors(options =>
            {
                options.WithOrigins("*");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
