using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Posts.Events.Features.PostComments;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapPostCommentEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostCommentAddedEventRequest>(message => message.PostComment.GetKey())
				.MapEventProducer<PostCommentUpdatedEventRequest>(message => message.PostComment.GetKey())
				.MapEventProducer<PostCommentDeletedEventRequest>(message => message.PostComment.GetKey());

			return riderConfigurator;
		}
	}
}
