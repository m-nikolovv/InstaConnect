using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Builders;

public class UsersPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public UsersPaginationQueryBuilder()
	{
		_page = UserDataFaker.GetPage();
		_pageSize = UserDataFaker.GetPageSize();
	}

	public UsersPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public UsersPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public UsersPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
