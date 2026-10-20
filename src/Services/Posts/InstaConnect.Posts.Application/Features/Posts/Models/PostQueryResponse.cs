using InstaConnect.Posts.Application.Features.PostImages.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryResponse(
	string Id,
	string UserId,
	string Title,
	string Content,
	string Summary,
	UserQueryResponse? User,
	ICollection<PostImageQueryResponse> PostImages,
	bool IsLikedByCurrentUser,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc);
