namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeCollectionResponse(
	PostCommentResponse? PostComment,
	UserResponse? User,
	ICollection<PostCommentLikeResponse> PostCommentLikes,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionResponse;
