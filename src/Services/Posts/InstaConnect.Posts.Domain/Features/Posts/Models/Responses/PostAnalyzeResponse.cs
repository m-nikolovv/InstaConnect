using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

public record PostAnalyzeResponse(
	PostId Id,
	UserId UserId,
	string Title,
	string Content,
	UserResponse? User,
	ICollection<PostImageResponse> PostImages,
	bool IsLikedByCurrentUser,
	string Summary,
	DateTimeOffset CreatedAtUtc,
	DateTimeOffset UpdatedAtUtc) : IEntityResponse;
