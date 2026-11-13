using InstaConnect.Posts.Presentation.Features.PostCommentImages.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record PostCommentApiResponse(
	string Id,
	string CommentId,
	string UserId,
	string Content,
	string Summary,
	UserApiResponse? User,
	PostApiResponse? Post,
	ICollection<PostCommentImageApiResponse> PostCommentImages,
	bool IsLikedByCurrentUser,
	int LikeCount,
	int ImageCount,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
