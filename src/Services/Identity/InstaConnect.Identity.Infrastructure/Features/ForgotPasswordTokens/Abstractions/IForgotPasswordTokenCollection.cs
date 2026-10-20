namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCollection : IMongoDbCollection<ForgotPasswordToken>
{
	public IForgotPasswordTokenFluent AggregateFluent();

	public Task UpdateAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<ForgotPasswordToken> entities,
		CancellationToken cancellationToken);
}
