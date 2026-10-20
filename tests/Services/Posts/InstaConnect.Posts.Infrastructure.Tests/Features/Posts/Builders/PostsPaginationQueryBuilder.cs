using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;

public class PostsPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public PostsPaginationQueryBuilder()
	{
		_page = PostDataFaker.GetPage();
		_pageSize = PostDataFaker.GetPageSize();
	}

	public PostsPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public PostsPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public PostsPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
