namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostApiResponse(
	string Id,
	string UserId,
	string Title,
	string Content,
	UserApiResponse? User,
	ICollection<PostImageApiResponse> PostImages,
	bool IsLikedByCurrentUser,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
