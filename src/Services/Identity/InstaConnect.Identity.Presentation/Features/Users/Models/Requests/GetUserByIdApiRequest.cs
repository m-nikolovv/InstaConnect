namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetUserByIdApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string CurrentId) : ICurrentUserableApiRequest;
