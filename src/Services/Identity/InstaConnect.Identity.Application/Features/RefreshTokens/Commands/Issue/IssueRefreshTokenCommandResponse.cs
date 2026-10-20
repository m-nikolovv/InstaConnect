using InstaConnect.Identity.Application.Features.RefreshTokens.Models;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;

public record IssueRefreshTokenCommandResponse(SessionTokenCommandResponse Response);
