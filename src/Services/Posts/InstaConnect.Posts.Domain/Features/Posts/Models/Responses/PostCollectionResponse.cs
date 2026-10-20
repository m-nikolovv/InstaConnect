namespace InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

public record PostCollectionResponse(
	UserResponse? User,
	ICollection<PostResponse> Posts,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionResponse;
