using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCacheHandler
{
	public Task DeleteAsync(EmailConfirmationTokenId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<EmailConfirmationTokenId> ids, CancellationToken cancellationToken);
}
