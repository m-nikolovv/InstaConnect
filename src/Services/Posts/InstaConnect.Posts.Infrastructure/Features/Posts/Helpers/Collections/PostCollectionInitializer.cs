namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostCollectionInitializer : MongoDbCollectionInitializer<Post>
{
	public PostCollectionInitializer(IMongoCollection<Post> collection)
		: base(
			collection,
			[
				new(Builders<Post>.IndexKeys.Ascending(c => c.Id.Id)),
				new(Builders<Post>.IndexKeys.Ascending(c => c.UserId.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<Post>.IndexKeys.Ascending(c => c.UserId)),
				new(Builders<Post>.IndexKeys.Ascending(c => c.CreatedAtUtc))
			])
	{
	}
}
