using Microsoft.Extensions.DependencyInjection;
using Moonhotels.Hub.Infrastructure.ExternalApis;

namespace Moonhotels.Hub.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IHotelLegsApi, HotelLegsApi>();
        }
    }
}