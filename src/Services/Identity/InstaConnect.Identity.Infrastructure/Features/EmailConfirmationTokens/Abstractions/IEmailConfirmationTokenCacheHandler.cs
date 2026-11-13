using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCacheHandler
{
	public Task<EmailConfirmationToken?> GetByIdAsync(EmailConfirmationTokenId id, CancellationToken cancellationToken);

	public Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(EmailConfirmationTokenId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(EmailConfirmationTokenId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(EmailConfirmationTokenId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<EmailConfirmationTokenId> ids, CancellationToken cancellationToken);
}
