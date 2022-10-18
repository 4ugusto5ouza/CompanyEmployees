using CompanyEmployees.Domain.Interfaces;
using CompanyEmployees.Infrastructure.Context;
using CompanyEmployees.Infrastructure.Repositories.RepositoryManager;
using CompanyEmployees.Service.Interfaces;
using CompanyEmployees.Service.Logger;
using CompanyEmployees.Service.Services.ServiceManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyEmployees.Presentation.WebAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) => 
            services.Configure<IISOptions>(options => { });

        public static void ConfigureLoggerService(this IServiceCollection services) => 
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) => 
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSQLContext(this IServiceCollection services, IConfiguration configuration) => 
            services.AddDbContext<CompanyEmployeesContext>(opts => 
                    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    }
}
