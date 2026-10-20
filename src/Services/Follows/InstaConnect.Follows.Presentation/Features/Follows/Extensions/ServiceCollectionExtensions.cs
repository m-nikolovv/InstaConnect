using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Options;

namespace InstaConnect.Follows.Presentation.Features.Follows.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddFollowServices()
		{
			serviceCollection.AddValidatedOptions<FollowOptions>(FollowOptions.SectionName);

			return serviceCollection;
		}
	}
}
