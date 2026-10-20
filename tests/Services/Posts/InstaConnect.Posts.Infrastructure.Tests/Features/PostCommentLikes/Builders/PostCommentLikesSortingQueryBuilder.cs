using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikesSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private PostCommentLikesSortTerm _sortTerm;

	public PostCommentLikesSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentLikeDataFaker.GetSortTerm();
	}

	public PostCommentLikesSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public PostCommentLikesSortingQueryBuilder WithSortTerm(IEnumTransformer<PostCommentLikesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public PostCommentLikesSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
