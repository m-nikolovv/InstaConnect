namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeResponse(
	PostCommentLikeId Id,
	UserResponse? User,
	PostCommentResponse? PostComment,
	DateTimeOffset CreatedAtUtc) : IEntityResponse;

