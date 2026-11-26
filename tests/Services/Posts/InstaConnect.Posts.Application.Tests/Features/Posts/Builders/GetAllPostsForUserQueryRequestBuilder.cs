namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsForUserQueryRequestBuilder
{
	private string _userId;
	private string _title;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostsForUserSortTerm _sortTerm;

	public GetAllPostsForUserQueryRequestBuilder(Post post)
	{
		_userId = post.UserId.Id;
		_title = DataFaker.GetPrefixString(post.Title);
		_currentUserId = post.UserId.Id;
		_page = PostDataFaker.GetPage();
		_pageSize = PostDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostDataFaker.GetForUserSortTerm();
	}

	public GetAllPostsForUserQueryRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostsForUserQueryRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetAllPostsForUserQueryRequestBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public GetAllPostsForUserQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostsForUserQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostsForUserQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostsForUserQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostsForUserQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostsForUserQueryRequestBuilder WithSortTerm(IEnumTransformer<PostsForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostsForUserQueryRequest Build()
	{
		return new(_userId, _currentUserId, _title, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
