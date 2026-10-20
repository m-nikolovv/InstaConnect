using InstaConnect.Posts.Events.Features.PostImages;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Domain.Features.Posts.Mappings;

internal class PostDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<Post, PostAddedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<PostEventRequest>(config)));

		config.NewConfig<Post, PostUpdatedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<PostEventRequest>(config)));

		config.NewConfig<Post, PostDeletedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<PostEventRequest>(config)));

		config.NewConfig<Post, PostEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id,
				src.UserId.Id,
				src.Title,
				src.Content,
				src.Summary.Value,
				src.User.Adapt<UserEventRequest>(config)!,
				src.PostImages.Adapt<ICollection<PostImageEventRequest>>(config),
				src.CreatedAtUtc,
				src.UpdatedAtUtc));
	}
}
