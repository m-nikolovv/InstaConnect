namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeCollectionApiResponse(
	PostCommentApiResponse? PostComment,
	UserApiResponse? User,
	ICollection<PostCommentLikeApiResponse> PostCommentLikes,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionApiResponse;
