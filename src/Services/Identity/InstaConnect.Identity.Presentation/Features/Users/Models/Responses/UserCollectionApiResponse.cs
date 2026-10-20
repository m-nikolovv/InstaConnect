namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserCollectionApiResponse(
	ICollection<UserApiResponse> Users,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionApiResponse;
