using EmployeeManagement.BusinessLayer;
using EmployeeManagement.DataAccessLayer;
using EmployeeManagementService.Mappers;
using EmployeeManagementService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagementService.Setup
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
            services.AddControllers();

            // Dependency Injection of BL, DAL, Repository
            services.AddScoped<IEmployeeDAL, EmployeeDAL>();
            services.AddScoped<IEmployeeBL, EmployeeBL>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Registering automappers
            services.AddAutoMapper(typeof(EmployeeProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
