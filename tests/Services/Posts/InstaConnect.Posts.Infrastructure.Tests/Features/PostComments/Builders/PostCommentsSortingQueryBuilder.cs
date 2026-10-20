namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

public class PostCommentsSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private PostCommentsSortTerm _sortTerm;

	public PostCommentsSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentDataFaker.GetSortTerm();
	}

	public PostCommentsSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public PostCommentsSortingQueryBuilder WithSortTerm(IEnumTransformer<PostCommentsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public PostCommentsSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
