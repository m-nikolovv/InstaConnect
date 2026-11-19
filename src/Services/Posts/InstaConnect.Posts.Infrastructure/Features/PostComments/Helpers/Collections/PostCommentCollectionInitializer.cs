namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentCollectionInitializer : MongoDbCollectionInitializer<PostComment>
{
	public PostCommentCollectionInitializer(IMongoCollection<PostComment> collection)
		: base(
			collection,
			[
				Builders<PostComment>.IndexKeys.Ascending(c => c.Id.Id.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<PostComment>.IndexKeys.Ascending(c => c.UserId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<PostComment>.IndexKeys.Ascending(c => c.Id.Id).ToIndex(),
				Builders<PostComment>.IndexKeys.Ascending(c => c.UserId).ToIndex()
			])
	{
	}
}
