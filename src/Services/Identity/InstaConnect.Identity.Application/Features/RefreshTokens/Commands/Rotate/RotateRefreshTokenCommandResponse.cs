using InstaConnect.Identity.Application.Features.RefreshTokens.Models;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

public record RotateRefreshTokenCommandResponse(SessionTokenCommandResponse Response);
