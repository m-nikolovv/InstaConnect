using InstaConnect.Chats.Application.Features.Users.Abstractions;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

public record GetAllChatsQueryRequest(
	string ParticipantTwoName,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	ChatsSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllChatsQueryResponse>, ISortableQueryRequest<ChatsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
