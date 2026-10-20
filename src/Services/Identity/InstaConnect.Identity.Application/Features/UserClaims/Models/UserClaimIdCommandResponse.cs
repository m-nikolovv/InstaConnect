using InstaConnect.Common.Domain.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Features.UserClaims.Models;

public record UserClaimIdCommandResponse(string Id, ApplicationClaims Claim);
