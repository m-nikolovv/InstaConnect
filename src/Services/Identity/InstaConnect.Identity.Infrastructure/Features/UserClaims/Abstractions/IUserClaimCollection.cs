namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimCollection : IMongoDbCollection<UserClaim>
{
	public IUserClaimFluent AggregateFluent();

	public Task DeleteAsync(
		UserClaim entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken);
}
