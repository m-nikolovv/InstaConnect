namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCollection : IMongoDbCollection<EmailConfirmationToken>
{
	public IEmailConfirmationTokenFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<EmailConfirmationToken> entities,
		CancellationToken cancellationToken);
}
