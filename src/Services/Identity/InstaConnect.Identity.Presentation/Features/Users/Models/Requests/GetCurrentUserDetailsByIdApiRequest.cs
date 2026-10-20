namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetCurrentUserDetailsByIdApiRequest([UserIdFromClaim] string CurrentId) : ICurrentUserableApiRequest;
