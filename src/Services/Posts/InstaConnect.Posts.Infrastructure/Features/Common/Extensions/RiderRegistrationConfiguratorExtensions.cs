using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Events.Features.PostComments;
using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

public static class RiderRegistrationConfiguratorExtensions
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

		public IRiderRegistrationConfigurator MapPostCommentEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostCommentAddedEventRequest>(message => message.PostComment.GetKey())
				.MapEventProducer<PostCommentUpdatedEventRequest>(message => message.PostComment.GetKey())
				.MapEventProducer<PostCommentDeletedEventRequest>(message => message.PostComment.GetKey());

			return riderConfigurator;
		}

		public IRiderRegistrationConfigurator MapPostLikeEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostLikeAddedEventRequest>(message => message.PostLike.GetKey())
				.MapEventProducer<PostLikeDeletedEventRequest>(message => message.PostLike.GetKey());

			return riderConfigurator;
		}

		public IRiderRegistrationConfigurator MapPostCommentLikeEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostCommentLikeAddedEventRequest>(message => message.PostCommentLike.GetKey())
				.MapEventProducer<PostCommentLikeDeletedEventRequest>(message => message.PostCommentLike.GetKey());

			return riderConfigurator;
		}
	}
}
