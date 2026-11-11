namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCollection : IMongoDbCollection<ForgotPasswordToken>
{
	public IForgotPasswordTokenFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<ForgotPasswordToken> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		ForgotPasswordToken entity,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<ForgotPasswordToken> filter,
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
