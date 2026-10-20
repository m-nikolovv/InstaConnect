using InstaConnect.Posts.Events.Features.PostLikes;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Mappings;

internal class PostLikeDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostLike, PostLikeAddedEventRequest>()
			.ConstructUsing(src => new(
				src.Adapt<PostLikeEventRequest>(config)));

		config.NewConfig<PostLike, PostLikeDeletedEventRequest>()
			.ConstructUsing(src => new(
				src.Adapt<PostLikeEventRequest>(config)));

		config.NewConfig<PostLike, PostLikeEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.UserId.Id,
				src.User.Adapt<UserEventRequest>(config)!,
				src.Post.Adapt<PostEventRequest>(config)!,
				src.CreatedAtUtc));
	}
}
