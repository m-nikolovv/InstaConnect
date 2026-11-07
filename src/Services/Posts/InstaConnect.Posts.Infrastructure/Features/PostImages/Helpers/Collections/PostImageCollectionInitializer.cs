namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageCollectionInitializer : MongoDbCollectionInitializer<PostImage>
{
	public PostImageCollectionInitializer(IMongoCollection<PostImage> collection)
		: base(
			collection,
			[
				Builders<PostImage>.IndexKeys.Ascending(c => c.Id.Id.Id).ToIndex(),
				Builders<PostImage>.IndexKeys.Ascending(c => c.Id.Id).ToIndex()
			])
	{
	}
}
