namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessagesSortingQuery(
	CommonSortOrder Order,
	ChatMessagesSortTerm Term) : ISortingQuery<ChatMessagesSortTerm>;
