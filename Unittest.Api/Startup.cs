using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Unittest.Api.Extensions;
using Unittest.Api.Repositories;
using Unittest.Api.Services;
using Unittest.Api.Validators;

namespace Unittest.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INotificationSender, EmailSender>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerCreateValidator>());
            services.AddHealthChecks();
            services.AddSqlServer(Configuration, "Unittest.Api");
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unittest.Api v1"));
            }


            app.UseRouting();

            app.ConfigureHealthCheck();


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}