namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCollection : IMongoDbCollection<ForgotPasswordToken>
{
	public IForgotPasswordTokenFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken);
}
