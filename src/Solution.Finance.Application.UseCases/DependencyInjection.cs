using Microsoft.Extensions.DependencyInjection;
using Solution.Finance.Application.UseCases.Features;
using Solution.Finance.Application.UseCases.IFeatures;
using System.Reflection;

namespace Solution.Finance.Application.UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUsuarioHandler, UsuarioHandler>();
            return services;
        }
    }
}
