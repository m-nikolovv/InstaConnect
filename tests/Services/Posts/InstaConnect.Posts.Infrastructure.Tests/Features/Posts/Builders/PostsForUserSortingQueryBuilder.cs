namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;

public class PostsForUserSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private PostsForUserSortTerm _sortTerm;

	public PostsForUserSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostDataFaker.GetForUserSortTerm();
	}

	public PostsForUserSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public PostsForUserSortingQueryBuilder WithSortTerm(IEnumTransformer<PostsForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public PostsForUserSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
