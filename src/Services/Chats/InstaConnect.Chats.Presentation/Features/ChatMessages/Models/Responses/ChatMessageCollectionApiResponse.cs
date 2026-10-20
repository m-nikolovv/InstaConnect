namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Responses;

public record ChatMessageCollectionApiResponse(
	ChatApiResponse? Chat,
	UserApiResponse? Sender,
	ICollection<ChatMessageApiResponse> ChatMessages,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionApiResponse;
