namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCollection : IMongoDbCollection<EmailConfirmationToken>
{
	public IEmailConfirmationTokenFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<EmailConfirmationToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<EmailConfirmationToken> entities,
		CancellationToken cancellationToken);
}
