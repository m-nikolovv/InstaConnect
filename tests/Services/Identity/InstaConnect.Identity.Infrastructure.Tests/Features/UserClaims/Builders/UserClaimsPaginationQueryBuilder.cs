using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Builders;

public class UserClaimsPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public UserClaimsPaginationQueryBuilder()
	{
		_page = UserClaimDataFaker.GetPage();
		_pageSize = UserClaimDataFaker.GetPageSize();
	}

	public UserClaimsPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public UserClaimsPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public UserClaimsPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
