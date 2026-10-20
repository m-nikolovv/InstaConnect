using InstaConnect.Posts.Events.Features.PostCommentLikes;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostCommentLike, PostCommentLikeAddedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<PostCommentLikeEventRequest>(config)));

		config.NewConfig<PostCommentLike, PostCommentLikeDeletedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<PostCommentLikeEventRequest>(config)));

		config.NewConfig<PostCommentLike, PostCommentLikeEventRequest>()
			.ConstructUsing(src => new(
				src.Id.CommentId.Id.Id,
				src.Id.CommentId.CommentId,
				src.Id.UserId.Id,
				src.User.Adapt<UserEventRequest>(config)!,
				src.PostComment.Adapt<PostCommentEventRequest>(config)!,
				src.CreatedAtUtc));
	}
}
