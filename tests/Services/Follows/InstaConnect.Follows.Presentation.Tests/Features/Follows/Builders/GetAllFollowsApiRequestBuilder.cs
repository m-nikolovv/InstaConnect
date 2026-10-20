using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Builders;

public class GetAllFollowsApiRequestBuilder
{
	private string _followerId;
	private string _followingName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private FollowsSortTerm _sortTerm;

	public GetAllFollowsApiRequestBuilder(Follow follow)
	{
		_followerId = follow.Id.FollowerId.Id;
		_followingName = DataFaker.GetPrefixString(follow.Following!.Name.Value);
		_currentUserId = follow.Id.FollowerId.Id;
		_page = FollowDataFaker.GetPage();
		_pageSize = FollowDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = FollowDataFaker.GetSortTerm();
	}

	public GetAllFollowsApiRequestBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public GetAllFollowsApiRequestBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public GetAllFollowsApiRequestBuilder WithFollowingName(IStringTransformer transformer)
	{
		_followingName = transformer.Transform(_followingName);

		return this;
	}

	public GetAllFollowsApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllFollowsApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllFollowsApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllFollowsApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllFollowsApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllFollowsApiRequestBuilder WithSortTerm(IEnumTransformer<FollowsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllFollowsApiRequest Build()
	{
		return new(_followerId, _currentUserId, _followingName, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
