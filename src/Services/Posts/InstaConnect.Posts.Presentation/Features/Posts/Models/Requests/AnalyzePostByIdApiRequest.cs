using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record AnalyzePostByIdApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string CurrentUserId) : ICurrentUserableApiRequest;
