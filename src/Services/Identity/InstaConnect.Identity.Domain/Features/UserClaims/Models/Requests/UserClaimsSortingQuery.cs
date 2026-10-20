namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimsSortingQuery(
	CommonSortOrder Order,
	UserClaimsSortTerm Term) : ISortingQuery<UserClaimsSortTerm>;
