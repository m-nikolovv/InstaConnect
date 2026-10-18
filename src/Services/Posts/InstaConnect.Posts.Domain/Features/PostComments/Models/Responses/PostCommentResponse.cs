using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

public record PostCommentResponse(
		PostCommentId Id,
		UserId UserId,
		string Content,
		Summary Summary,
		UserResponse? User,
		PostResponse? Post,
		ICollection<PostCommentImageResponse> PostCommentImages,
		bool IsLikedByCurrentUser,
		DateTimeOffset CreatedAtUtc,
		DateTimeOffset UpdatedAtUtc) : IEntityResponse;
