namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowCollectionInitializer : MongoDbCollectionInitializer<Follow>
{
	public FollowCollectionInitializer(IMongoCollection<Follow> collection)
		: base(
			collection,
			[
				Builders<Follow>.IndexKeys.Ascending(c => c.Id.FollowerId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<Follow>.IndexKeys.Ascending(c => c.Id.FollowingId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<Follow>.IndexKeys.Ascending(c => c.Id.FollowerId).ToIndex(),
				Builders<Follow>.IndexKeys.Ascending(c => c.Id.FollowingId).ToIndex()
			])
	{
	}
}
