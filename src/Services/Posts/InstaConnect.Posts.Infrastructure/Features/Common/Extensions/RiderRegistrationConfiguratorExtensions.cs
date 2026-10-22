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
				.MapEventProducer<PostAddedEventRequest>(context => context.Message.Post.GetKey())
				.MapEventProducer<PostUpdatedEventRequest>(context => context.Message.Post.GetKey())
				.MapEventProducer<PostDeletedEventRequest>(context => context.Message.Post.GetKey());

			return riderConfigurator;
		}

		public IRiderRegistrationConfigurator MapPostCommentEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostCommentAddedEventRequest>(context => context.Message.PostComment.GetKey())
				.MapEventProducer<PostCommentUpdatedEventRequest>(context => context.Message.PostComment.GetKey())
				.MapEventProducer<PostCommentDeletedEventRequest>(context => context.Message.PostComment.GetKey());

			return riderConfigurator;
		}

		public IRiderRegistrationConfigurator MapPostLikeEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostLikeAddedEventRequest>(context => context.Message.PostLike.GetKey())
				.MapEventProducer<PostLikeDeletedEventRequest>(context => context.Message.PostLike.GetKey());

			return riderConfigurator;
		}

		public IRiderRegistrationConfigurator MapPostCommentLikeEventProducer()
		{
			riderConfigurator
				.MapEventProducer<PostCommentLikeAddedEventRequest>(context => context.Message.PostCommentLike.GetKey())
				.MapEventProducer<PostCommentLikeDeletedEventRequest>(context => context.Message.PostCommentLike.GetKey());

			return riderConfigurator;
		}
	}
}
