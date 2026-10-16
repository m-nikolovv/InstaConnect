using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostImages.Builders;

public class PostImageIdBuilderFactory
{
	public PostImageIdBuilder Create(PostImageId id)
	{
		return new(id);
	}
}
