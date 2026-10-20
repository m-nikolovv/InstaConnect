using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

public class PostLikesPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public PostLikesPaginationQueryBuilder()
	{
		_page = PostLikeDataFaker.GetPage();
		_pageSize = PostLikeDataFaker.GetPageSize();
	}

	public PostLikesPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public PostLikesPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public PostLikesPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
