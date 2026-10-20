using InstaConnect.Follows.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record FollowApiResponse(
	string FollowerId,
	string FollowingId,
	UserApiResponse? Follower,
	UserApiResponse? Following,
	bool IsFollowedByCurrentUser,
	DateTimeOffset CreatedAtUtc);
