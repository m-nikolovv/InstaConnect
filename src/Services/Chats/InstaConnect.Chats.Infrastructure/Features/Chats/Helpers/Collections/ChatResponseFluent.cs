using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

internal class ChatResponseFluent :
	MongoDbResponseFluent<ChatResponse>, IChatResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatsSortTermerFactory _sortTermerFactory;

	public ChatResponseFluent(
		IPaginator paginator,
		IAggregateFluent<ChatResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IChatsSortTermerFactory sortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
	}

	public IChatResponseFluent ApplySorting(ChatsSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IChatResponseFluent ApplyPagination(ChatsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
