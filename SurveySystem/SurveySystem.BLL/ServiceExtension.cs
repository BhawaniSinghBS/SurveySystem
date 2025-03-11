using Microsoft.Extensions.DependencyInjection;
using SurveySystem.BLL.SurveyService;
using SurveySystem.BLL.UserService;
namespace SurveySystem.BLL
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<ISurveyService, SurveyService.SurveyService>();
            services.AddScoped<IUserService, UserService.UserService>();
            return services;
        }
    }
}
