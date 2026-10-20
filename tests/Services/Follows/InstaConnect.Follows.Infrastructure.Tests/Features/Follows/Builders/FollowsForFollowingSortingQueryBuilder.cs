using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

public class FollowsForFollowingSortingQueryBuilder
{
	private CommonSortOrder _sortOrder;
	private FollowsForFollowingSortTerm _sortTerm;

	public FollowsForFollowingSortingQueryBuilder()
	{
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = FollowDataFaker.GetForFollowingSortTerm();
	}

	public FollowsForFollowingSortingQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public FollowsForFollowingSortingQueryBuilder WithSortTerm(IEnumTransformer<FollowsForFollowingSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public FollowsForFollowingSortingQuery Build()
	{
		return new(_sortOrder, _sortTerm);
	}
}
