using Microsoft.Extensions.DependencyInjection;
using Moonhotels.Hub.Domain.Interfaces;
using Moonhotels.Hub.Infrastructure.ExternalApis;

namespace Moonhotels.Hub.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IHotelLegsApi, HotelLegsApi>();
            services.AddTransient<ITravelDoorXApi, TravelDoorXApi>();
        }
    }
}