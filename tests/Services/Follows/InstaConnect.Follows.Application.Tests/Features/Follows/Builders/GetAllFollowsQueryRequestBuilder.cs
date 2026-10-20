namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class GetAllFollowsQueryRequestBuilder
{
	private string _followerId;
	private string _followingName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private FollowsSortTerm _sortTerm;

	public GetAllFollowsQueryRequestBuilder(Follow follow)
	{
		_followerId = follow.Id.FollowerId.Id;
		_followingName = DataFaker.GetPrefixString(follow.Following!.Name.Value);
		_currentUserId = follow.Id.FollowerId.Id;
		_page = FollowDataFaker.GetPage();
		_pageSize = FollowDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = FollowDataFaker.GetSortTerm();
	}

	public GetAllFollowsQueryRequestBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public GetAllFollowsQueryRequestBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public GetAllFollowsQueryRequestBuilder WithFollowingName(IStringTransformer transformer)
	{
		_followingName = transformer.Transform(_followingName);

		return this;
	}

	public GetAllFollowsQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllFollowsQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllFollowsQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllFollowsQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllFollowsQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllFollowsQueryRequestBuilder WithSortTerm(IEnumTransformer<FollowsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllFollowsQueryRequest Build()
	{
		return new(_followerId, _followingName, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
