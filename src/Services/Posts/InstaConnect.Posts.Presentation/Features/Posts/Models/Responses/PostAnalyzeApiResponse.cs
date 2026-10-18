namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostAnalyzeApiResponse(
	string Id,
	string UserId,
	string Title,
	string Content,
	UserApiResponse? User,
	ICollection<PostImageApiResponse> PostImages,
	bool IsLikedByCurrentUser,
	string Summary,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
