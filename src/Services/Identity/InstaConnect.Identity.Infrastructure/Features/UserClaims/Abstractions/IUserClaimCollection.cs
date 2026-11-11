namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimCollection : IMongoDbCollection<UserClaim>
{
	public IUserClaimFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		UserClaim entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken);
}
