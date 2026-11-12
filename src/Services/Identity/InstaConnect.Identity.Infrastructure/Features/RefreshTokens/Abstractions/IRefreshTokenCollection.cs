namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCollection
{
	public IRefreshTokenFluent AggregateFluent();

	public Task AddAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<RefreshToken> entities,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		RefreshToken entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken);
}
