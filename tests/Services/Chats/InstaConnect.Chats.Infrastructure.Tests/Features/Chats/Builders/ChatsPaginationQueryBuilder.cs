using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Builders;

public class ChatsPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public ChatsPaginationQueryBuilder()
	{
		_page = ChatDataFaker.GetPage();
		_pageSize = ChatDataFaker.GetPageSize();
	}

	public ChatsPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public ChatsPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public ChatsPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
