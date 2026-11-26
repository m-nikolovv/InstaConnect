namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsForUserQueryRequestBuilder
{
	private string _userId;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostCommentsForUserSortTerm _sortTerm;

	public GetAllPostCommentsForUserQueryRequestBuilder(PostComment postComment)
	{
		_userId = postComment.UserId.Id;
		_currentUserId = postComment.UserId.Id;
		_page = PostCommentDataFaker.GetPage();
		_pageSize = PostCommentDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentDataFaker.GetForUserSortTerm();
	}

	public GetAllPostCommentsForUserQueryRequestBuilder WithUserId(UserId userId, IStringTransformer transformer)
	{
		_userId = transformer.Transform(userId.Id);

		return this;
	}

	public GetAllPostCommentsForUserQueryRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetAllPostCommentsForUserQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostCommentsForUserQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostCommentsForUserQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostCommentsForUserQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostCommentsForUserQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostCommentsForUserQueryRequestBuilder WithSortTerm(IEnumTransformer<PostCommentsForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostCommentsForUserQueryRequest Build()
	{
		return new(_userId, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
