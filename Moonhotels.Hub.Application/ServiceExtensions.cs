using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moonhotels.Hub.Application.Interfaces;
using Moonhotels.Hub.Application.Services;
using Moonhotels.Hub.Domain.Interfaces;
using Moonhotels.Hub.Infrastructure.Connectors;
using System.Reflection;

namespace Moonhotels.Hub.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ISearchService, SearchService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IProviderConnector, HotelLegsConnector>();
            services.AddTransient<IProviderConnector, TravelDoorXConnector>();
        }
    }
}