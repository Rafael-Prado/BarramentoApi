using BarramentoBusiness.LeituraArquivo;
using BarramentoBusiness.Services;
using BarramentoRepository.Repositories.ApiDogsFacts;
using Microsoft.Extensions.DependencyInjection;

namespace BarramentoApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //repository
            services.AddScoped<IApiDogFactsRepository, ApiDogFactsRepository>();
            //services
            services.AddScoped<IApiFactsService, ApiFactsService>();
            services.AddScoped<IRegraArquivos, RegraArquivos>();

            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }
    }
}
