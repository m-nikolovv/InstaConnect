using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;

public class GetAllUserClaimsApiRequestBuilder
{
	private string _id;
	private string _currentId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private UserClaimsSortTerm _sortTerm;

	public GetAllUserClaimsApiRequestBuilder(UserClaim userClaim)
	{
		_id = userClaim.Id.Id.Id;
		_currentId = userClaim.Id.Id.Id;
		_page = UserClaimDataFaker.GetPage();
		_pageSize = UserClaimDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = UserClaimDataFaker.GetSortTerm();
	}

	public GetAllUserClaimsApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetAllUserClaimsApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetAllUserClaimsApiRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetAllUserClaimsApiRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetAllUserClaimsApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllUserClaimsApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllUserClaimsApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllUserClaimsApiRequestBuilder WithSortTerm(IEnumTransformer<UserClaimsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllUserClaimsApiRequest Build()
	{
		return new(_id, _currentId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
