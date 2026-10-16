using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostImages.Mappings;

internal class PostImageDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PostImage, PostImageEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.ImageId,
				src.Url.Value,
				src.CreatedAtUtc));
	}
}
