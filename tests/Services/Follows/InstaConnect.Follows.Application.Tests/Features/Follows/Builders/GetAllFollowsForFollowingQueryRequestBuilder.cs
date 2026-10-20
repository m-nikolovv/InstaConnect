namespace InstaConnect.Follows.Application.Tests.Features.Follows.Builders;

public class GetAllFollowsForFollowingQueryRequestBuilder
{
	private string _followingId;
	private string _followerName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private FollowsForFollowingSortTerm _sortTerm;

	public GetAllFollowsForFollowingQueryRequestBuilder(Follow follow)
	{
		_followingId = follow.Id.FollowingId.Id;
		_followerName = DataFaker.GetPrefixString(follow.Follower!.Name.Value);
		_currentUserId = follow.Id.FollowingId.Id;
		_page = FollowDataFaker.GetPage();
		_pageSize = FollowDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = FollowDataFaker.GetForFollowingSortTerm();
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithFollowerName(IStringTransformer transformer)
	{
		_followerName = transformer.Transform(_followerName);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequestBuilder WithSortTerm(IEnumTransformer<FollowsForFollowingSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllFollowsForFollowingQueryRequest Build()
	{
		return new(_followingId, _followerName, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
