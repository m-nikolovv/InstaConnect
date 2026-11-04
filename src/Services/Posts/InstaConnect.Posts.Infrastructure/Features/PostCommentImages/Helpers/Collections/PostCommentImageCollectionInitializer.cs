namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageCollectionInitializer : MongoDbCollectionInitializer<PostCommentImage>
{
	public PostCommentImageCollectionInitializer(IMongoCollection<PostCommentImage> collection)
		: base(
			collection,
			[
				new(Builders<PostCommentImage>.IndexKeys.Ascending(c => c.Id.Id.Id.Id)),
				new(Builders<PostCommentImage>.IndexKeys.Ascending(c => c.Id.Id))
			])
	{
	}
}
