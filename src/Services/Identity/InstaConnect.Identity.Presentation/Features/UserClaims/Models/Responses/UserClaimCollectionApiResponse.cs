namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Responses;

public record UserClaimCollectionApiResponse(
	UserApiResponse? User,
	ICollection<UserClaimApiResponse> UserClaims,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionApiResponse;
