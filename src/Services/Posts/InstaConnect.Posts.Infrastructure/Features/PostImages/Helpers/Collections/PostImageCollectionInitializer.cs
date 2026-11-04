namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageCollectionInitializer : MongoDbCollectionInitializer<PostImage>
{
	public PostImageCollectionInitializer(IMongoCollection<PostImage> collection)
		: base(
			collection,
			[
				new(Builders<PostImage>.IndexKeys.Ascending(c => c.Id.Id.Id)),
				new(Builders<PostImage>.IndexKeys.Ascending(c => c.Id.Id))
			])
	{
	}
}
