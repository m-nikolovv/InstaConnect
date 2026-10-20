namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;

public class PostsForUserFilterQueryBuilder
{
	private string _userId;
	private string _title;

	public PostsForUserFilterQueryBuilder(Post post)
	{
		_userId = post.UserId.Id;
		_title = DataFaker.GetPrefixString(post.Title);
	}

	public PostsForUserFilterQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public PostsForUserFilterQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public PostsForUserFilterQueryBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public PostsForUserFilterQuery Build()
	{
		return new(new(_userId), _title);
	}
}
