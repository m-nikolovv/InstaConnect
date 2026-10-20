namespace InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

public record FollowCollectionResponse(
	UserResponse? Follower,
	UserResponse? Following,
	ICollection<FollowResponse> Follows,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionResponse;
