namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record GetAllUsersQuery(
	UsersFilterQuery Filter,
	UsersSortingQuery Sorting,
	UsersPaginationQuery Pagination,
	CurrentUserQuery Current)
	: ISortableQuery<UsersSortingQuery, UsersSortTerm>, IPaginatableQuery<UsersPaginationQuery>, ICurrentUserableQuery;
