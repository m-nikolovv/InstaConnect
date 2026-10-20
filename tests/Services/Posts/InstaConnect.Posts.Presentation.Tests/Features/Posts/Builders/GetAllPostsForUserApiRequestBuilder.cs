namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetAllPostsForUserApiRequestBuilder
{
	private string _userId;
	private string _title;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostsForUserSortTerm _sortTerm;

	public GetAllPostsForUserApiRequestBuilder(Post post)
	{
		_userId = post.UserId.Id;
		_title = DataFaker.GetPrefixString(post.Title);
		_currentUserId = post.UserId.Id;
		_page = PostDataFaker.GetPage();
		_pageSize = PostDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostDataFaker.GetForUserSortTerm();
	}

	public GetAllPostsForUserApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostsForUserApiRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetAllPostsForUserApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostsForUserApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostsForUserApiRequestBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public GetAllPostsForUserApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostsForUserApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostsForUserApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostsForUserApiRequestBuilder WithSortTerm(IEnumTransformer<PostsForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostsForUserApiRequest Build()
	{
		return new(_userId, _currentUserId, _title, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
