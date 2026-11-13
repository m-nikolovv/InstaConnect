using InstaConnect.Posts.Application.Features.PostCommentImages.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentQueryResponse(
	string Id,
	string CommentId,
	string UserId,
	string Content,
	string Summary,
	UserQueryResponse? User,
	PostQueryResponse? Post,
	ICollection<PostCommentImageQueryResponse> PostCommentImages,
	bool IsLikedByCurrentUser,
	int LikeCount,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
