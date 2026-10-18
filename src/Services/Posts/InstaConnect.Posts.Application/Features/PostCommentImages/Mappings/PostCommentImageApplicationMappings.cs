using Mapster;

namespace InstaConnect.Posts.Application.Features.PostCommentImages.Mappings;

internal class PostCommentImageApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostCommentImageResponse, PostCommentImageQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.Id.Id.Id,
				src.Id.Id.CommentId,
				src.Id.ImageId,
				src.Url.Value,
				src.CreatedAtUtc));
	}
}
