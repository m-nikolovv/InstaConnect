namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostIdRangeBuilderFactory
{
	private readonly PostIdBuilderFactory _idBuilderFactory;

	public PostIdRangeBuilderFactory()
	{
		_idBuilderFactory = new();
	}

	public PostIdRangeBuilder Create(ICollection<PostId> ids)
	{
		return new([.. ids.Select(_idBuilderFactory.Create)]);
	}
}
