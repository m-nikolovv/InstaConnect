namespace InstaConnect.Identity.Application.Features.UserClaims.Queries.GetAll;

public record GetAllUserClaimsQueryRequest(
	string Id,
	string CurrentId,
	CommonSortOrder SortOrder,
	UserClaimsSortTerm SortTerm,
	int Page,
	int PageSize)
	: IQueryRequest<GetAllUserClaimsQueryResponse>, ISortableQueryRequest<UserClaimsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
