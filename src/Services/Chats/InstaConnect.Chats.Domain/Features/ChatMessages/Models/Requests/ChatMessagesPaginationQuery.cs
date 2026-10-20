namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessagesPaginationQuery(
	int Page,
	int PageSize) : IPaginationQuery;
