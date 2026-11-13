namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenCollectionInitializer : MongoDbCollectionInitializer<RefreshToken>
{
	public RefreshTokenCollectionInitializer(IMongoCollection<RefreshToken> collection)
		: base(
			collection,
			[
				Builders<RefreshToken>.IndexKeys.Ascending(c => c.Id.Id.Id).ToIndex(),
				Builders<RefreshToken>.IndexKeys.Ascending(c => c.Id.Id).ToIndex(),
				Builders<RefreshToken>.IndexKeys.Ascending(c => c.ExpiresAtUtc).ToIndex().WithExpiration()
			])
	{
	}
}
