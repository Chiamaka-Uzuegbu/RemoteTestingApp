using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.AuthRepository;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.DocumentUploadRepository;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.PersonDetailRepository;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.ReviewRepository;
using RemoteTestingApp.Infrastructure.Helpers;
using RemoteTestingApp.Infrastructure.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void ConfigureDBContextPool(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<ApplicationDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                optionBuilder.EnableSensitiveDataLogging();
            });
        }

        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            });
        }


        public static void ResolveInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.ConfigureDBContextPool(config);
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IPersonalDetailsRepository, PersonalDetailsRepository>();
            services.AddScoped< IReviewDocumentRepository, ReviewDocumentRepository> ();
            services.AddScoped<IUploadDocumentRepository, UploadDocumentRepository>();
            services.AddSingleton<IFileLogger, AppLoggerService>();


        }

    }
}
