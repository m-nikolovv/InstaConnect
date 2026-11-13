namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCollection
{
	public IForgotPasswordTokenFluent AggregateFluent();

	public Task AddAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken);
}
