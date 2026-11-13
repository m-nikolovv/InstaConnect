using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Posts.Events.Features.PostLikes;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapPostLikeEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostLikeAddedEventRequest>(message => message.PostLike.GetKey())
				.MapEventProducer<PostLikeDeletedEventRequest>(message => message.PostLike.GetKey());

			return riderConfigurator;
		}
	}
}
