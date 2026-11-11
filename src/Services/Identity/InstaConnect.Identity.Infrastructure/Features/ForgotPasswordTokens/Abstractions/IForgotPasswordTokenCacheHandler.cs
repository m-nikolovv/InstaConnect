using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCacheHandler
{
	public Task<ForgotPasswordToken?> GetByIdAsync(ForgotPasswordTokenId id);

	public Task AddAsync(ForgotPasswordToken entity);

	public Task<bool?> ExistsByIdAsync(ForgotPasswordTokenId id);

	public Task AddExistsByIdAsync(ForgotPasswordTokenId id, bool exists);

	public Task DeleteAsync(ForgotPasswordTokenId id);

	public Task DeleteRangeAsync(IEnumerable<ForgotPasswordTokenId> ids);
}
