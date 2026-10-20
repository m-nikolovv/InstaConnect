using InstaConnect.Posts.Application.Features.PostImages.Models;
using InstaConnect.Posts.Presentation.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.PostImages.Mappings;

internal class PostImagePresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostImageQueryResponse, PostImageApiResponse>()
			.ConstructUsing(src => new(
				src.Id,
				src.ImageId,
				src.Url,
				src.CreatedAtUtc));
	}
}
