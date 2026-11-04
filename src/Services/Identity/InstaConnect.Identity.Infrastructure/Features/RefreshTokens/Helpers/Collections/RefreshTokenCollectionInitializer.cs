namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenCollectionInitializer : MongoDbCollectionInitializer<RefreshToken>
{
	public RefreshTokenCollectionInitializer(IMongoCollection<RefreshToken> collection)
		: base(
			collection,
			[
				new(Builders<RefreshToken>.IndexKeys.Ascending(c => c.Id.Id.Id)),
				new(Builders<RefreshToken>.IndexKeys.Ascending(c => c.Id.Id))
			])
	{
	}
}
