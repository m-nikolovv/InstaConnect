namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCollection : IMongoDbCollection<RefreshToken>
{
	public IRefreshTokenFluent AggregateFluent();

	public Task UpdateAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);
}
