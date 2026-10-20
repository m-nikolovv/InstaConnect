using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

public class PostLikesForUserSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private PostLikesForUserSortTerm _sortTerm;

	public PostLikesForUserSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostLikeDataFaker.GetForUserSortTerm();
	}

	public PostLikesForUserSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public PostLikesForUserSortingQueryBuilder WithSortTerm(IEnumTransformer<PostLikesForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public PostLikesForUserSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
