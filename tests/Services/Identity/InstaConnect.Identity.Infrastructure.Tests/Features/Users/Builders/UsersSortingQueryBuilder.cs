using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Builders;

public class UsersSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private UsersSortTerm _sortTerm;

	public UsersSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = UserDataFaker.GetSortTerm();
	}

	public UsersSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public UsersSortingQueryBuilder WithSortTerm(IEnumTransformer<UsersSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public UsersSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
