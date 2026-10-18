using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostComments.Mappings;

internal class PostCommentDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostComment, PostCommentAddedEventRequest>()
			.ConstructUsing(src => new(
				src.Adapt<PostCommentEventRequest>(config)));

		config.NewConfig<PostComment, PostCommentUpdatedEventRequest>()
			.ConstructUsing(src => new(
				src.Adapt<PostCommentEventRequest>(config)));

		config.NewConfig<PostComment, PostCommentDeletedEventRequest>()
			.ConstructUsing(src => new(
				src.Adapt<PostCommentEventRequest>(config)));

		config.NewConfig<PostComment, PostCommentEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.CommentId,
				src.UserId.Id,
				src.Content,
				src.Summary.Value,
				src.User.Adapt<UserEventRequest>(config)!,
				src.Post.Adapt<PostEventRequest>(config)!,
				src.PostCommentImages.Adapt<ICollection<PostCommentImageEventRequest>>(config),
				src.CreatedAtUtc,
				src.UpdatedAtUtc));
	}
}
