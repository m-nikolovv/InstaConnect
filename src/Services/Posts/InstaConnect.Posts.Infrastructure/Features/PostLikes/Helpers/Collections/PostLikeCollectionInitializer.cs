namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeCollectionInitializer : MongoDbCollectionInitializer<PostLike>
{
	public PostLikeCollectionInitializer(IMongoCollection<PostLike> collection)
		: base(
			collection,
			[
				Builders<PostLike>.IndexKeys.Ascending(c => c.Id.Id.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<PostLike>.IndexKeys.Ascending(c => c.Id.UserId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<PostLike>.IndexKeys.Ascending(c => c.Id.Id).ToIndex(),
				Builders<PostLike>.IndexKeys.Ascending(c => c.Id.UserId).ToIndex()
			])
	{
	}
}
