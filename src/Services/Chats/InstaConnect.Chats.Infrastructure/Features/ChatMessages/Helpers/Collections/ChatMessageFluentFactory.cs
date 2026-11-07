namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageFluentFactory : IChatMessageFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatMessageIncluderFactory _includerFactory;
	private readonly IChatMessagesSortTermerFactory _sortTermerFactory;
	private readonly IChatMessageResponseFluentFactory _responseFluentFactory;

	public ChatMessageFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IChatMessageIncluderFactory includerFactory,
		IChatMessagesSortTermerFactory sortTermerFactory,
		IChatMessageResponseFluentFactory responseFluentFactory)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatMessageFluent Create(IAggregateFluent<ChatMessage> fluent)
	{
		return new ChatMessageFluent(
			_paginator,
			fluent,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_responseFluentFactory);
	}
}
