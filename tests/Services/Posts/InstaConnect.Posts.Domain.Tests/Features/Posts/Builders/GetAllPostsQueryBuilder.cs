namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class GetAllPostsQueryBuilder
{
	private string _userName;
	private string _title;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostsSortTerm _sortTerm;

	public GetAllPostsQueryBuilder(Post post)
	{
		_userName = DataFaker.GetPrefixString(post.User!.Name.Value);
		_title = DataFaker.GetPrefixString(post.Title);
		_currentUserId = post.UserId.Id;
		_page = PostDataFaker.GetPage();
		_pageSize = PostDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostDataFaker.GetSortTerm();
	}

	public GetAllPostsQueryBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public GetAllPostsQueryBuilder WithTitle(IStringTransformer transformer)
	{
		_title = transformer.Transform(_title);

		return this;
	}

	public GetAllPostsQueryBuilder WithCurrentUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostsQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostsQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostsQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostsQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostsQueryBuilder WithSortTerm(IEnumTransformer<PostsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostsQuery Build()
	{
		return new(
				   new(
					   new(_userName),
					   _title),
				   new(_sortOrder, _sortTerm),
				   new(_page, _pageSize),
				   new(
					   new(_currentUserId)));
	}
}
