using Mapster;

namespace InstaConnect.Posts.Application.Features.PostImages.Mappings;

internal class PostImageApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostImageResponse, PostImageQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.ImageId,
				src.Url.Value,
				src.CreatedAtUtc));
	}
}
