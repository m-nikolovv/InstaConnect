namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeCollectionInitializer : MongoDbCollectionInitializer<PostLike>
{
	public PostLikeCollectionInitializer(IMongoCollection<PostLike> collection)
		: base(
			collection,
			[
				new(Builders<PostLike>.IndexKeys.Ascending(c => c.Id.Id.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<PostLike>.IndexKeys.Ascending(c => c.Id.UserId.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<PostLike>.IndexKeys.Ascending(c => c.Id.Id)),
				new(Builders<PostLike>.IndexKeys.Ascending(c => c.Id.UserId))
			])
	{
	}
}
