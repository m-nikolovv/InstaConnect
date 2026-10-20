namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetPostByIdApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string CurrentUserId) : ICurrentUserableApiRequest;
