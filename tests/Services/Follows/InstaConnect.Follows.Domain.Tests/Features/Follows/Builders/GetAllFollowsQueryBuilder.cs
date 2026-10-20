namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;

public class GetAllFollowsQueryBuilder
{
	private string _followerId;
	private string _followingName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private FollowsSortTerm _sortTerm;

	public GetAllFollowsQueryBuilder(Follow follow)
	{
		_followerId = follow.Id.FollowerId.Id;
		_followingName = DataFaker.GetPrefixString(follow.Following!.Name.Value);
		_currentUserId = follow.Id.FollowerId.Id;
		_page = FollowDataFaker.GetPage();
		_pageSize = FollowDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = FollowDataFaker.GetSortTerm();
	}

	public GetAllFollowsQueryBuilder WithFollowerId(UserId followerId, IStringTransformer? transformer = null)
	{
		_followerId = transformer.TryTransform(followerId.Id);

		return this;
	}

	public GetAllFollowsQueryBuilder WithFollowerId(IStringTransformer transformer)
	{
		_followerId = transformer.Transform(_followerId);

		return this;
	}

	public GetAllFollowsQueryBuilder WithFollowingName(IStringTransformer transformer)
	{
		_followingName = transformer.Transform(_followingName);

		return this;
	}

	public GetAllFollowsQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllFollowsQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllFollowsQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllFollowsQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllFollowsQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllFollowsQueryBuilder WithSortTerm(IEnumTransformer<FollowsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllFollowsQuery Build()
	{
		return new(
			new(
				new(_followerId),
				new(_followingName)),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(
				new(_currentUserId)));
	}
}
