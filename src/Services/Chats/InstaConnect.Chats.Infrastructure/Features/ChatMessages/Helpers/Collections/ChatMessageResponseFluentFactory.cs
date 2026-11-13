namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageResponseFluentFactory : IChatMessageResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatMessagesSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public ChatMessageResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IChatMessagesSortTermerFactory sortTermerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_paginator = paginator;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IChatMessageResponseFluent Create(IAggregateFluent<ChatMessageResponse> fluent)
	{
		return new ChatMessageResponseFluent(
			_paginator,
			_sortOrdererFactory,
			_sortTermerFactory,
			_fluentHandlerFactory.CreateResponse(fluent));
	}
}
