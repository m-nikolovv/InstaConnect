using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Mappings;

internal class PostCommentImageDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostCommentImage, PostCommentImageEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.Id.Id,
				src.Id.Id.CommentId,
				src.Id.ImageId,
				src.Url.Value,
				src.CreatedAtUtc));
	}
}
