using InstaConnect.Common.Application.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Requests.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Follows.Application.Features.Follows.Extensions;

namespace InstaConnect.Follows.Application.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddApplication()
		{
			serviceCollection
				.AddUserServices()
				.AddFollowServices();

			serviceCollection
				.AddRequests(FollowsApplicationReference.Assembly)
				.AddMappers(FollowsApplicationReference.Assembly, CommonApplicationReference.Assembly)
				.AddValidations(FollowsApplicationReference.Assembly);

			return serviceCollection;
		}
	}
}
