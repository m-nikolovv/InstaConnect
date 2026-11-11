using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCacheHandler
{
	public Task<EmailConfirmationToken?> GetByIdAsync(EmailConfirmationTokenId id);

	public Task AddAsync(EmailConfirmationToken entity);

	public Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities);

	public Task<bool?> ExistsByIdAsync(EmailConfirmationTokenId id);

	public Task AddExistsByIdAsync(EmailConfirmationTokenId id, bool exists);

	public Task DeleteAsync(EmailConfirmationTokenId id);

	public Task DeleteRangeAsync(IEnumerable<EmailConfirmationTokenId> ids);
}
