namespace InstaConnect.Identity.Domain.Features.Users.Models.Responses;

public record UserCollectionResponse(
	ICollection<UserResponse> Users,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionResponse;

