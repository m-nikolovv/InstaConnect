namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;

public class PostsFilterQueryBuilder
{
	private string _userName;
	private string _title;

	public PostsFilterQueryBuilder(Post post)
	{
		_userName = DataFaker.GetPrefixString(post.User!.Name.Value);
		_title = DataFaker.GetPrefixString(post.Title);
	}

	public PostsFilterQueryBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public PostsFilterQueryBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public PostsFilterQuery Build()
	{
		return new(new(_userName), _title);
	}
}
