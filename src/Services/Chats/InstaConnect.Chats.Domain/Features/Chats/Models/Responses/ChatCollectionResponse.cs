namespace InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

public record ChatCollectionResponse(
	UserResponse? ParticipantOne,
	UserResponse? ParticipantTwo,
	ICollection<ChatResponse> Chats,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionResponse;
