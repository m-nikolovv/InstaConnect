namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostCollectionApiResponse(
	UserApiResponse? User,
	ICollection<PostApiResponse> Posts,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionApiResponse;
