namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentIdRangeBuilderFactory
{
	private readonly PostCommentIdBuilderFactory _idBuilderFactory;

	public PostCommentIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public PostCommentIdRangeBuilder Create(ICollection<PostCommentId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
