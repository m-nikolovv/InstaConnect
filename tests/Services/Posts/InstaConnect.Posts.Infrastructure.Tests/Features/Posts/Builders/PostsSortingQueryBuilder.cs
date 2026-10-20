namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;

public class PostsSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private PostsSortTerm _sortTerm;

	public PostsSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostDataFaker.GetSortTerm();
	}

	public PostsSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public PostsSortingQueryBuilder WithSortTerm(IEnumTransformer<PostsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public PostsSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
