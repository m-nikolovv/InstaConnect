namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowCollectionInitializer : MongoDbCollectionInitializer<Follow>
{
	public FollowCollectionInitializer(IMongoCollection<Follow> collection)
		: base(
			collection,
			[
				new(Builders<Follow>.IndexKeys.Ascending(c => c.Id.FollowerId.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<Follow>.IndexKeys.Ascending(c => c.Id.FollowingId.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<Follow>.IndexKeys.Ascending(c => c.Id.FollowerId)),
				new(Builders<Follow>.IndexKeys.Ascending(c => c.Id.FollowingId))
			])
	{
	}
}
