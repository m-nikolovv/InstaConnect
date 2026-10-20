namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Responses;

public record ChatCollectionApiResponse(
	UserApiResponse? ParticipantOne,
	UserApiResponse? ParticipantTwo,
	ICollection<ChatApiResponse> Chats,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionApiResponse;
