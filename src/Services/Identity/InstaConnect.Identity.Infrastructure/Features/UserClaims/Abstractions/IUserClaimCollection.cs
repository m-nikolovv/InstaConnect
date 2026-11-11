namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimCollection : IMongoDbCollection<UserClaim>
{
	public IUserClaimFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		UserClaim entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken);
}
