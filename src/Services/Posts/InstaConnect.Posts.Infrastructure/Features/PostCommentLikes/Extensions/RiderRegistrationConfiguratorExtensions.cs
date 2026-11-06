using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapPostCommentLikeEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostCommentLikeAddedEventRequest>(message => message.PostCommentLike.GetKey())
				.MapEventProducer<PostCommentLikeDeletedEventRequest>(message => message.PostCommentLike.GetKey());

			return riderConfigurator;
		}
	}
}
