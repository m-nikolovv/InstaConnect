namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCommandRepository
{
	public Task<EmailConfirmationToken?> GetByIdAsync(
		EmailConfirmationTokenId id,
		EmailConfirmationTokenInclude include,
		CancellationToken cancellationToken);

	public Task<EmailConfirmationToken?> GetByIdAsync(
		EmailConfirmationTokenId id,
		CancellationToken cancellationToken);

	public Task<ICollection<EmailConfirmationToken>> GetByIdRangeAsync(
		IEnumerable<EmailConfirmationTokenId> ids,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		EmailConfirmationTokenId id,
		CancellationToken cancellationToken);

	public Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken);

	public Task UpdateAsync(EmailConfirmationToken entity, CancellationToken cancellationToken);

	public Task DeleteAsync(EmailConfirmationToken entity, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken);
}
