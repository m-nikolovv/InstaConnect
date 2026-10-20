namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetPostLikeByIdApiRequest(
	[FromRoute] string Id,
	[FromRoute] string UserId,
	[UserIdFromClaim] string CurrentUserId) : ICurrentUserableApiRequest;
