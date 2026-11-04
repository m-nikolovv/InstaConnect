namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimCollectionInitializer : MongoDbCollectionInitializer<UserClaim>
{
	public UserClaimCollectionInitializer(IMongoCollection<UserClaim> collection)
		: base(
			collection,
			[
				new(Builders<UserClaim>.IndexKeys.Ascending(c => c.Id.Id.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<UserClaim>.IndexKeys.Ascending(c => c.Id.Id))
			])
	{
	}
}
