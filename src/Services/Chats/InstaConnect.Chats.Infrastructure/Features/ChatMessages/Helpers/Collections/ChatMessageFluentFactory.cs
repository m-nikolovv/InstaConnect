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
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IChatMessageFluent Create(IAggregateFluent<ChatMessage> fluent)
	{
		return new ChatMessageFluent(
			fluent,
			_paginator,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_responseFluentFactory);
	}
}
