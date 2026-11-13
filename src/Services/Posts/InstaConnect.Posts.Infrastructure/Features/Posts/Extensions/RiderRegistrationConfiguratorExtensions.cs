using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Posts.Events.Features.Posts;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapPostEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostAddedEventRequest>(message => message.Post.GetKey())
				.MapEventProducer<PostUpdatedEventRequest>(message => message.Post.GetKey())
				.MapEventProducer<PostDeletedEventRequest>(message => message.Post.GetKey());

			return riderConfigurator;
		}
	}
}
