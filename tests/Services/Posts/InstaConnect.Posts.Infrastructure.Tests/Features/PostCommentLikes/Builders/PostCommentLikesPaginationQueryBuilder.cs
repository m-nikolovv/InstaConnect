using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikesPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public PostCommentLikesPaginationQueryBuilder()
	{
		_page = PostCommentLikeDataFaker.GetPage();
		_pageSize = PostCommentLikeDataFaker.GetPageSize();
	}

	public PostCommentLikesPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public PostCommentLikesPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public PostCommentLikesPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
