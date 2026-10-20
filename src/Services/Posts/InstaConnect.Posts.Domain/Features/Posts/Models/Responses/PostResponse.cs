using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

public record PostResponse(
	PostId Id,
	UserId UserId,
	string Title,
	string Content,
	Summary Summary,
	UserResponse? User,
	ICollection<PostImageResponse> PostImages,
	bool IsLikedByCurrentUser,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc) : IEntityResponse;
