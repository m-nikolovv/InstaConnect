namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatResponseFluentFactory : IChatResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatsSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public ChatResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IChatsSortTermerFactory sortTermerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_paginator = paginator;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IChatResponseFluent Create(IAggregateFluent<ChatResponse> fluent)
	{
		return new ChatResponseFluent(_paginator, _sortOrdererFactory, _sortTermerFactory, _fluentHandlerFactory.CreateResponse(fluent));
	}
}
