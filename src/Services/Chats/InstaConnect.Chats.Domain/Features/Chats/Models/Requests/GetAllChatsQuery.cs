namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetAllChatsQuery(
	ChatsFilterQuery Filter,
	ChatsSortingQuery Sorting,
	ChatsPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<ChatsSortingQuery, ChatsSortTerm>, IPaginatableQuery<ChatsPaginationQuery>, ICurrentUserableQuery;
