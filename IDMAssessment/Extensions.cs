using BusinessFacade;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DataAccess.Repository;
using Services;

namespace IDMAssessment.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => {
            });
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IDataAccess, DataAccessManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigurePostgreSqlContext(this IServiceCollection services
            , IConfiguration configuration) =>
            services.AddDbContext<DataAccessContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("MSSQLConnection")));

        //public static void ConfigureSwagger(this IServiceCollection services)
        //{
        //    services.AddSwaggerGen(s =>
        //    {
        //        s.SwaggerDoc("v1", new OpenApiInfo
        //        {
        //            Title = "Suweger",
        //            Version = "v1"
        //        });
        //        s.SwaggerDoc("v2", new OpenApiInfo
        //        {
        //            Title = "Suweger",
        //            Version = "v2"
        //        });
        //        //var xmlFile = $"{typeof(MainAplikasi.Presentation.AssemblyReference).Assembly.GetName().Name}.xml";
        //        //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //        s.IncludeXmlComments(xmlPath);
        //    });
        //}

    }
}
