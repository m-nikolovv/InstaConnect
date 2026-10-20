namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

public class PostCommentsForUserSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private PostCommentsForUserSortTerm _sortTerm;

	public PostCommentsForUserSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentDataFaker.GetForUserSortTerm();
	}

	public PostCommentsForUserSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public PostCommentsForUserSortingQueryBuilder WithSortTerm(IEnumTransformer<PostCommentsForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public PostCommentsForUserSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
