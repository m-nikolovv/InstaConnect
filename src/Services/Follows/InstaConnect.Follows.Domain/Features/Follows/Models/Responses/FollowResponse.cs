namespace InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

public record FollowResponse(
	FollowId Id,
	UserResponse? Follower,
	UserResponse? Following,
	bool IsFollowedByCurrentUser,
	DateTimeOffset CreatedAtUtc) : IEntityResponse;
