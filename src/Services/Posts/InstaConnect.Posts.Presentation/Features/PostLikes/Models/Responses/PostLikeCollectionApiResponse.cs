namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record PostLikeCollectionApiResponse(
	PostApiResponse? Post,
	UserApiResponse? User,
	ICollection<PostLikeApiResponse> PostLikes,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionApiResponse;
