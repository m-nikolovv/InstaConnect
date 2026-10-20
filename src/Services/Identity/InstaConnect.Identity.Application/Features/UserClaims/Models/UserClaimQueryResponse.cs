using InstaConnect.Common.Domain.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Features.UserClaims.Models;

public record UserClaimQueryResponse(
	string Id,
	ApplicationClaims Claim,
	UserQueryResponse? User,
	DateTimeOffset CreatedAtUtc);
