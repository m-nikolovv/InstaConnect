namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record GetAllFollowsQuery(
	FollowsFilterQuery Filter,
	FollowsSortingQuery Sorting,
	FollowsPaginationQuery Pagination,
	CurrentUserQuery CurrentUser)
	: ISortableQuery<FollowsSortingQuery, FollowsSortTerm>, IPaginatableQuery<FollowsPaginationQuery>, ICurrentUserableQuery;
