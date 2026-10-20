namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

public record PostLikeResponse(
		PostLikeId Id,
		UserResponse? User,
		PostResponse? Post,
		DateTimeOffset CreatedAtUtc) : IEntityResponse;
