using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeIdRangeBuilderFactory
{
	private readonly PostCommentLikeIdBuilderFactory _idBuilderFactory;

	public PostCommentLikeIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public PostCommentLikeIdRangeBuilder Create(ICollection<PostCommentLikeId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
