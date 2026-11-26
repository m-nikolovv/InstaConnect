namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimCollection
{
	public IUserClaimFluent AggregateFluent();

	public Task AddAsync(
		UserClaim entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<UserClaim> entities,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		UserClaim entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken);
}
