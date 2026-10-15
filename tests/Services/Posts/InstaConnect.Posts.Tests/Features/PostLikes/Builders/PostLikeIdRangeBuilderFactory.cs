using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeIdRangeBuilderFactory
{
	private readonly PostLikeIdBuilderFactory _idBuilderFactory;

	public PostLikeIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public PostLikeIdRangeBuilder Create(ICollection<PostLikeId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
