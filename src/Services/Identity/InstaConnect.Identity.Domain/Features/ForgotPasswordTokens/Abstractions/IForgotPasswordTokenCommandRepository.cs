namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCommandRepository
{
	public Task<ForgotPasswordToken?> GetByIdAsync(
		ForgotPasswordTokenId id,
		ForgotPasswordTokenInclude include,
		CancellationToken cancellationToken);

	public Task<ForgotPasswordToken?> GetByIdAsync(
		ForgotPasswordTokenId id,
		CancellationToken cancellationToken);

	public Task<ICollection<ForgotPasswordToken>> GetByIdRangeAsync(
		IEnumerable<ForgotPasswordTokenId> ids,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		ForgotPasswordTokenId id,
		CancellationToken cancellationToken);

	public Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken);

	public Task UpdateAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

	public Task DeleteAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken);
}
