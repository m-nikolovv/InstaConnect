using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

public class PostLikesSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private PostLikesSortTerm _sortTerm;

	public PostLikesSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostLikeDataFaker.GetSortTerm();
	}

	public PostLikesSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public PostLikesSortingQueryBuilder WithSortTerm(IEnumTransformer<PostLikesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public PostLikesSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
