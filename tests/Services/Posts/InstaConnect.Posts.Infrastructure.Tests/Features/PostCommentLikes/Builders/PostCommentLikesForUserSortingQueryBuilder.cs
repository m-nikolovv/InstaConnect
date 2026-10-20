using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikesForUserSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private PostCommentLikesForUserSortTerm _sortTerm;

	public PostCommentLikesForUserSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentLikeDataFaker.GetForUserSortTerm();
	}

	public PostCommentLikesForUserSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public PostCommentLikesForUserSortingQueryBuilder WithSortTerm(IEnumTransformer<PostCommentLikesForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public PostCommentLikesForUserSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
