using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurveySystem.DAL.DataContext;
using SurveySystem.DAL.Repositories.Survey;
using SurveySystem.DAL.Repositories.UserRepo;

namespace SurveySystem.DAL
{
    public static class ServiceExtension
    {

        public static IServiceCollection AddDALServices(this IServiceCollection services, string connectionStrings)
        {
            try
            {
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped<ISurveyRepository, SurveyRepository>();
                services.AddScoped<IUserRepository, UserRepository>();

                services.AddDbContext<SurveyDbContext>(options =>
                // options.UseSqlServer(connectionStrings));

                options.UseSqlServer(connectionStrings, sqlOptions =>
                           sqlOptions.MigrationsAssembly("SurveySystem")));


                //services.AddDbContext<SurveyDbContext>(options =>
                //        options.UseLazyLoadingProxies()
                //        .UseSqlServer(connectionStrings));

                //services.AddDbContext<SurveyDbContext>(options =>
                //        options.UseLazyLoadingProxies()
                //       .UseSqlServer(connectionStrings, sqlOptions =>
                //           sqlOptions.MigrationsAssembly("SurveySystem"))
                //);


                //options.UseLazyLoadingProxies()
                //       .UseSqlServer(connectionStrings, sqlOptions =>
                //           sqlOptions.MigrationsAssembly("SurveySystem.DAL")) 
                //);

                return services;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
