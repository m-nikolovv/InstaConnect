using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostImages.Builders;

public class PostImageIdRangeBuilderFactory
{
	private readonly PostImageIdBuilderFactory _idBuilderFactory;

	public PostImageIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public PostImageIdRangeBuilder Create(ICollection<PostImageId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
