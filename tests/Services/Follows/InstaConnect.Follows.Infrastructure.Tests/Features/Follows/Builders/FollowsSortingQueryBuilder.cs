using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

public class FollowsSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private FollowsSortTerm _sortTerm;

	public FollowsSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = FollowDataFaker.GetSortTerm();
	}

	public FollowsSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public FollowsSortingQueryBuilder WithSortTerm(IEnumTransformer<FollowsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public FollowsSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
