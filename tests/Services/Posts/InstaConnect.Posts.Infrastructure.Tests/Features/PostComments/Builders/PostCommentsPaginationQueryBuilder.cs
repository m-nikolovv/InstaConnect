using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

public class PostCommentsPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public PostCommentsPaginationQueryBuilder()
	{
		_page = PostCommentDataFaker.GetPage();
		_pageSize = PostCommentDataFaker.GetPageSize();
	}

	public PostCommentsPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public PostCommentsPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public PostCommentsPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
