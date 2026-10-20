namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeEquals
{
	extension(PostCommentLike entity)
	{
		public bool Matches(PostCommentLike postCommentLike)
		{
			return entity.Id.Matches(postCommentLike.Id) &&
				   entity.CreatedAtUtc == postCommentLike.CreatedAtUtc;
		}
	}

	extension(PostCommentLikeId p)
	{
		public bool Matches(PostCommentLikeId id)
		{
			return p.Matches(id.CommentId, id.UserId);
		}

		public bool Matches(PostCommentId id, UserId userId)
		{
			return p.Matches(id.Id.Id, id.CommentId, userId.Id);
		}

		public bool Matches(string id, string commentId, string userId)
		{
			return p.CommentId.Matches(id, commentId) &&
				   p.UserId.Matches(userId);
		}
	}
}
