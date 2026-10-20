using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCommandService
{
	public Task<SessionToken> IssueAsync(IssueRefreshTokenCommand command, CancellationToken cancellationToken);

	public Task<SessionToken> RotateAsync(RotateRefreshTokenCommand command, CancellationToken cancellationToken);

	public Task DeleteAsync(DeleteRefreshTokenCommand command, CancellationToken cancellationToken);
}
