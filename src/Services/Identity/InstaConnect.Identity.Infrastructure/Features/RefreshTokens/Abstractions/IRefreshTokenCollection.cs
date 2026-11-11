namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCollection : IMongoDbCollection<RefreshToken>
{
	public IRefreshTokenFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken);
}
