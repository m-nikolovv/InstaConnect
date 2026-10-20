namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;

public class GetAllUserClaimsQueryBuilder
{
	private string _id;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private UserClaimsSortTerm _sortTerm;

	public GetAllUserClaimsQueryBuilder(UserClaim userClaim)
	{
		_id = userClaim.Id.Id.Id;
		_currentUserId = userClaim.Id.Id.Id;
		_page = UserClaimDataFaker.GetPage();
		_pageSize = UserClaimDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = UserClaimDataFaker.GetSortTerm();
	}

	public GetAllUserClaimsQueryBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetAllUserClaimsQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetAllUserClaimsQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllUserClaimsQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllUserClaimsQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllUserClaimsQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllUserClaimsQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllUserClaimsQueryBuilder WithSortTerm(IEnumTransformer<UserClaimsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllUserClaimsQuery Build()
	{
		return new(
			new(
				new(_id)),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(
				new(_currentUserId)));
	}
}
