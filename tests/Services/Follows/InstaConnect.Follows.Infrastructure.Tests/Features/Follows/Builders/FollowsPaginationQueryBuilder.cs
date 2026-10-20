using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

public class FollowsPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public FollowsPaginationQueryBuilder()
	{
		_page = FollowDataFaker.GetPage();
		_pageSize = FollowDataFaker.GetPageSize();
	}

	public FollowsPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public FollowsPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public FollowsPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
