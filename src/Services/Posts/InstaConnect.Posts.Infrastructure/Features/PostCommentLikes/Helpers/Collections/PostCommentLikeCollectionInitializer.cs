namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeCollectionInitializer : MongoDbCollectionInitializer<PostCommentLike>
{
	public PostCommentLikeCollectionInitializer(IMongoCollection<PostCommentLike> collection)
		: base(
			collection,
			[
				Builders<PostCommentLike>.IndexKeys.Ascending(c => c.Id.CommentId.Id.Id).Ascending(c => c.Id.CommentId.CommentId).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<PostCommentLike>.IndexKeys.Ascending(c => c.Id.UserId.Id).Ascending(c => c.CreatedAtUtc).ToIndex(),
				Builders<PostCommentLike>.IndexKeys.Ascending(c => c.Id.CommentId).ToIndex(),
				Builders<PostCommentLike>.IndexKeys.Ascending(c => c.Id.UserId).ToIndex()
			])
	{
	}
}
