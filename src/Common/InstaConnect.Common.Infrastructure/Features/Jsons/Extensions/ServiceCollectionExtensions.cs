using InstaConnect.Common.Infrastructure.Features.Jsons.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Jsons.Helpers;

namespace InstaConnect.Common.Infrastructure.Features.Jsons.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddJsons()
		{
			serviceCollection.AddScoped<IJsonConverter, JsonConverter>();

			return serviceCollection;
		}
	}
}
