using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;

public class PostCommentImageIdRangeBuilderFactory
{
	private readonly PostCommentImageIdBuilderFactory _idBuilderFactory;

	public PostCommentImageIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public PostCommentImageIdRangeBuilder Create(ICollection<PostCommentImageId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
