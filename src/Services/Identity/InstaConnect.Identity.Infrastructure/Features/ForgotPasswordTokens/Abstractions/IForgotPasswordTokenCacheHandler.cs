using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCacheHandler
{
	public Task<ForgotPasswordToken?> GetByIdAsync(ForgotPasswordTokenId id, CancellationToken cancellationToken);

	public Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(ForgotPasswordTokenId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(ForgotPasswordTokenId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(ForgotPasswordTokenId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ForgotPasswordTokenId> ids, CancellationToken cancellationToken);
}
