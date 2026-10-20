using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Options;
using InstaConnect.Follows.Tests.Features.Common.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Helpers;

using Microsoft.Extensions.Options;

namespace InstaConnect.Follows.Tests.Features.Follows.Extensions;

public static class FollowsWebApplicationFactoryExtensions
{
	extension(FollowsWebApplicationFactory webApplicationFactory)
	{
		public IFollowNotificationClient CreateNotificationClient(UserId followingId)
		{
			var hubRoute = webApplicationFactory.Services
				.GetRequiredService<IOptions<FollowOptions>>()
				.Value
				.HubRoute;

			var connection = webApplicationFactory.CreateHubConnection(followingId.Id, hubRoute.TrimLeadingSlash());

			return new FollowNotificationClient(connection);
		}

		public IFollowEventClient CreateEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new FollowEventClient(eventClient);
		}
	}
}
