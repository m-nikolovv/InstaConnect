namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;

public record ChatMessageCollectionResponse(
	ChatResponse? Chat,
	UserResponse? Sender,
	ICollection<ChatMessageResponse> ChatMessages,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionResponse;
