namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsQueryRequestBuilder
{
	private string _userName;
	private string _title;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostsSortTerm _sortTerm;

	public GetAllPostsQueryRequestBuilder(Post post)
	{
		_userName = DataFaker.GetPrefixString(post.User!.Name.Value);
		_title = DataFaker.GetPrefixString(post.Title);
		_currentUserId = post.UserId.Id;
		_page = PostDataFaker.GetPage();
		_pageSize = PostDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostDataFaker.GetSortTerm();
	}

	public GetAllPostsQueryRequestBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public GetAllPostsQueryRequestBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public GetAllPostsQueryRequestBuilder WithCurrentUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostsQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostsQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostsQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostsQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostsQueryRequestBuilder WithSortTerm(IEnumTransformer<PostsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostsQueryRequest Build()
	{
		return new(_userName, _title, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
