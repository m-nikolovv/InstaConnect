namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

internal class ChatMessageCollectionResponseFactory : IChatMessageCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public ChatMessageCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public ChatMessageCollectionResponse Create(ChatResponse chat, ICollection<ChatMessageResponse> chatMessages, long totalCount, ChatMessagesPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new ChatMessageCollectionResponse(
			chat,
			null,
			chatMessages,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
