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
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
