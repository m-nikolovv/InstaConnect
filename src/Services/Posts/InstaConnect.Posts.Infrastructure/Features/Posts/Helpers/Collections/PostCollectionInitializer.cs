namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostCollectionInitializer : MongoDbCollectionInitializer<Post>
{
	public PostCollectionInitializer(IMongoCollection<Post> collection)
		: base(
			collection,
			[
				Builders<Post>.IndexKeys.Ascending(c => c.Id.Id).ToIndex(),
				Builders<Post>.IndexKeys.Ascending(c => c.UserId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<Post>.IndexKeys.Ascending(c => c.UserId).ToIndex(),
				Builders<Post>.IndexKeys.Ascending(c => c.CreatedAtUtc).ToIndex()
			])
	{
	}
}
