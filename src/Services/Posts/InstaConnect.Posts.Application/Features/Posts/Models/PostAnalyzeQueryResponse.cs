namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostAnalyzeQueryResponse(
	string Id,
	string UserId,
	string Title,
	string Content,
	UserQueryResponse? User,
	ICollection<PostImageQueryResponse> PostImages,
	bool IsLikedByCurrentUser,
	string Summary,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
