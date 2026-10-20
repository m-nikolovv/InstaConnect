namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class GetAllFollowsForFollowingApiRequestBuilder
{
	private string _followingId;
	private string _followerName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private FollowsForFollowingSortTerm _sortTerm;

	public GetAllFollowsForFollowingApiRequestBuilder(Follow follow)
	{
		_followingId = follow.Id.FollowingId.Id;
		_followerName = DataFaker.GetPrefixString(follow.Follower!.Name.Value);
		_currentUserId = follow.Id.FollowingId.Id;
		_page = FollowDataFaker.GetPage();
		_pageSize = FollowDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = FollowDataFaker.GetForFollowingSortTerm();
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithFollowerName(IStringTransformer transformer)
	{
		_followerName = transformer.Transform(_followerName);

		return this;
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllFollowsForFollowingApiRequestBuilder WithSortTerm(IEnumTransformer<FollowsForFollowingSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllFollowsForFollowingApiRequest Build()
	{
		return new(_followingId, _currentUserId, _followerName, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
