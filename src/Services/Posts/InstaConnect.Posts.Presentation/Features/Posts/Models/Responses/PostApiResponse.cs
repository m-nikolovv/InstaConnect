using InstaConnect.Posts.Presentation.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostApiResponse(
	string Id,
	string UserId,
	string Title,
	string Content,
	string Summary,
	UserApiResponse? User,
	ICollection<PostImageApiResponse> PostImages,
	bool IsLikedByCurrentUser,
	int LikeCount,
	int CommentCount,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
