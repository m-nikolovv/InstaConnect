using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Builders;

public class UserClaimsSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private UserClaimsSortTerm _sortTerm;

	public UserClaimsSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = UserClaimDataFaker.GetSortTerm();
	}

	public UserClaimsSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public UserClaimsSortingQueryBuilder WithSortTerm(IEnumTransformer<UserClaimsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public UserClaimsSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
