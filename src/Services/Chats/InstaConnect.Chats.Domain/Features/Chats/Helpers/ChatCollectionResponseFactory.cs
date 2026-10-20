namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

internal class ChatCollectionResponseFactory : IChatCollectionResponseFactory
{
	private readonly IPaginator _paginator;

	public ChatCollectionResponseFactory(IPaginator paginator)
	{
		_paginator = paginator;
	}

	public ChatCollectionResponse Create(UserResponse participantOne, ICollection<ChatResponse> chats, long totalCount, ChatsPaginationQuery pagination)
	{
		var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
		var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

		return new ChatCollectionResponse(
			participantOne,
			null,
			chats,
			pagination.Page,
			pagination.PageSize,
			totalCount,
			hasNextPage,
			hasPreviousPage);
	}
}
