using Mapster;

namespace InstaConnect.Posts.Presentation.Features.PostCommentImages.Mappings;

internal class PostCommentImagePresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostCommentImageQueryResponse, PostCommentImageApiResponse>()
			.ConstructUsing(src => new(
				src.Id,
				src.CommentId,
				src.ImageId,
				src.Url,
				src.CreatedAtUtc));
	}
}
