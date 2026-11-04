namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentCollectionInitializer : MongoDbCollectionInitializer<PostComment>
{
	public PostCommentCollectionInitializer(IMongoCollection<PostComment> collection)
		: base(
			collection,
			[
				new(Builders<PostComment>.IndexKeys.Ascending(c => c.Id.Id.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<PostComment>.IndexKeys.Ascending(c => c.UserId.Id).Ascending(c => c.CreatedAtUtc)),
				new(Builders<PostComment>.IndexKeys.Ascending(c => c.Id.Id)),
				new(Builders<PostComment>.IndexKeys.Ascending(c => c.UserId))
			])
	{
	}
}
