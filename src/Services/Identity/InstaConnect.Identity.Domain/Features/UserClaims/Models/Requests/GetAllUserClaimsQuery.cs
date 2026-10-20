namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record GetAllUserClaimsQuery(
	UserClaimsFilterQuery Filter,
	UserClaimsSortingQuery Sorting,
	UserClaimsPaginationQuery Pagination,
	CurrentUserQuery Current)
	: ISortableQuery<UserClaimsSortingQuery, UserClaimsSortTerm>, IPaginatableQuery<UserClaimsPaginationQuery>, ICurrentUserableQuery;
