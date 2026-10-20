using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Guids.Helpers;

namespace InstaConnect.Common.Infrastructure.Features.Guids.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddGuids()
		{
			serviceCollection.AddScoped<IGuidProvider, GuidProvider>();

			return serviceCollection;
		}
	}
}
