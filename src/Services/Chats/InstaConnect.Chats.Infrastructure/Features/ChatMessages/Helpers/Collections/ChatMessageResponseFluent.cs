namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Collections;

internal class ChatMessageResponseFluent : IChatMessageResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IChatMessagesSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<ChatMessageResponse> _fluentHandler;

	public ChatMessageResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IChatMessagesSortTermerFactory sortTermerFactory,
		IMongoDbResponseFluentHandler<ChatMessageResponse> fluentHandler)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
	}

	public IChatMessageResponseFluent ApplySorting(ChatMessagesSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IChatMessageResponseFluent ApplyPagination(ChatMessagesPaginationQuery query)
	{
		_fluentHandler.ApplyPagination(_paginator, query);

		return this;
	}

	public async Task<ChatMessageResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessageResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
