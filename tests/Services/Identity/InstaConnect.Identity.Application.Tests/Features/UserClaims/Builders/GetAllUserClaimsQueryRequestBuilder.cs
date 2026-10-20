namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;

public class GetAllUserClaimsQueryRequestBuilder
{
	private string _id;
	private string _currentId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private UserClaimsSortTerm _sortTerm;

	public GetAllUserClaimsQueryRequestBuilder(UserClaim userClaim)
	{
		_id = userClaim.Id.Id.Id;
		_currentId = userClaim.Id.Id.Id;
		_page = UserClaimDataFaker.GetPage();
		_pageSize = UserClaimDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = UserClaimDataFaker.GetSortTerm();
	}

	public GetAllUserClaimsQueryRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetAllUserClaimsQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetAllUserClaimsQueryRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetAllUserClaimsQueryRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetAllUserClaimsQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllUserClaimsQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllUserClaimsQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllUserClaimsQueryRequestBuilder WithSortTerm(IEnumTransformer<UserClaimsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllUserClaimsQueryRequest Build()
	{
		return new(_id, _currentId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
