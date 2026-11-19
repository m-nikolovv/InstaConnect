using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCacheHandler
{
	public Task DeleteAsync(ForgotPasswordTokenId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ForgotPasswordTokenId> ids, CancellationToken cancellationToken);
}
