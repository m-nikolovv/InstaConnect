namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCollection : IMongoDbCollection<EmailConfirmationToken>
{
	public IEmailConfirmationTokenFluent AggregateFluent();

	public Task UpdateAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		EmailConfirmationToken entity,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<EmailConfirmationToken> entities,
		CancellationToken cancellationToken);
}
