namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record PostCommentCollectionApiResponse(
	PostApiResponse? Post,
	UserApiResponse? User,
	ICollection<PostCommentApiResponse> PostComments,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionApiResponse;
