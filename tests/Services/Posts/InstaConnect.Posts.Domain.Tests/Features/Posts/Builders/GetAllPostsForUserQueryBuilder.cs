namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class GetAllPostsForUserQueryBuilder
{
	private string _userId;
	private string _title;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostsForUserSortTerm _sortTerm;

	public GetAllPostsForUserQueryBuilder(Post post)
	{
		_userId = post.UserId.Id;
		_title = DataFaker.GetPrefixString(post.Title);
		_currentUserId = post.UserId.Id;
		_page = PostDataFaker.GetPage();
		_pageSize = PostDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostDataFaker.GetForUserSortTerm();
	}

	public GetAllPostsForUserQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostsForUserQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetAllPostsForUserQueryBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public GetAllPostsForUserQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostsForUserQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostsForUserQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostsForUserQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostsForUserQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostsForUserQueryBuilder WithSortTerm(IEnumTransformer<PostsForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostsForUserQuery Build()
	{
		return new(
			new(
				new(_userId),
				_title),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(
				new(_currentUserId)));
	}
}
