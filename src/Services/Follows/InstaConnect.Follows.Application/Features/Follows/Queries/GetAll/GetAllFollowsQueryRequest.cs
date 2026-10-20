using InstaConnect.Follows.Application.Features.Users.Abstractions;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public record GetAllFollowsQueryRequest(
	string FollowerId,
	string FollowingName,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	FollowsSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllFollowsQueryResponse>, ISortableQueryRequest<FollowsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
