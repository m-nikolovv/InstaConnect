namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesQuery(
	ChatMessagesFilterQuery Filter,
	ChatMessagesSortingQuery Sorting,
	ChatMessagesPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<ChatMessagesSortingQuery, ChatMessagesSortTerm>, IPaginatableQuery<ChatMessagesPaginationQuery>, ICurrentUserableQuery;
