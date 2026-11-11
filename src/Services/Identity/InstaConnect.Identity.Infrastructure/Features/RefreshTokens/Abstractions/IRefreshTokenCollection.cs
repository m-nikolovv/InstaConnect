namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCollection : IMongoDbCollection<RefreshToken>
{
	public IRefreshTokenFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken);
}
