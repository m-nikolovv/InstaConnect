using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class GetAllFollowsForFollowingQueryBuilder
{
	private string _followingId;
	private string _followerName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private FollowsForFollowingSortTerm _sortTerm;

	public GetAllFollowsForFollowingQueryBuilder(Follow follow)
	{
		_followingId = follow.Id.FollowingId.Id;
		_followerName = DataFaker.GetPrefixString(follow.Follower!.Name.Value);
		_currentUserId = follow.Id.FollowingId.Id;
		_page = FollowDataFaker.GetPage();
		_pageSize = FollowDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = FollowDataFaker.GetForFollowingSortTerm();
	}

	public GetAllFollowsForFollowingQueryBuilder WithFollowingId(UserId followingId, IStringTransformer? transformer = null)
	{
		_followingId = transformer.TryTransform(followingId.Id);

		return this;
	}

	public GetAllFollowsForFollowingQueryBuilder WithFollowingId(IStringTransformer transformer)
	{
		_followingId = transformer.Transform(_followingId);

		return this;
	}

	public GetAllFollowsForFollowingQueryBuilder WithFollowerName(IStringTransformer transformer)
	{
		_followerName = transformer.Transform(_followerName);

		return this;
	}

	public GetAllFollowsForFollowingQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllFollowsForFollowingQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllFollowsForFollowingQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllFollowsForFollowingQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllFollowsForFollowingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllFollowsForFollowingQueryBuilder WithSortTerm(IEnumTransformer<FollowsForFollowingSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllFollowsForFollowingQuery Build()
	{
		return new(
			new(
				new(_followingId),
				new(_followerName)),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(
				new(_currentUserId)));
	}
}
