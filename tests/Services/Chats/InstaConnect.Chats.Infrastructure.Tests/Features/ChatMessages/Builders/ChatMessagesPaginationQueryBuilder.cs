using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Builders;

public class ChatMessagesPaginationQueryBuilder
{
	private int _page;
	private int _pageSize;

	public ChatMessagesPaginationQueryBuilder()
	{
		_page = ChatMessageDataFaker.GetPage();
		_pageSize = ChatMessageDataFaker.GetPageSize();
	}

	public ChatMessagesPaginationQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public ChatMessagesPaginationQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public ChatMessagesPaginationQuery Build()
	{
		return new(_page, _pageSize);
	}
}
