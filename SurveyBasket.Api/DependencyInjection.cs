using MapsterMapper;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;

namespace SurveyBasket.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {

            services
                .AddFluentValidation()
                .AddSwagger()
                .AddSwagger();


            services.AddScoped<IPollService, PollService>();


            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            services.AddOpenApi();
            return services;
        }

        public static IServiceCollection AddMapster(this IServiceCollection services)
        {


            var mapconfig = TypeAdapterConfig.GlobalSettings;
            mapconfig.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(mapconfig));
            return services;
        }

        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}
