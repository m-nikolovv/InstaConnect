using InstaConnect.Follows.Application.Features.Users.Abstractions;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;

public record GetAllFollowsForFollowingQueryRequest(
	string FollowingId,
	string FollowerName,
	string CurrentUserId,
	CommonSortOrder SortOrder,
	FollowsForFollowingSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllFollowsForFollowingQueryResponse>, ISortableQueryRequest<FollowsForFollowingSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
