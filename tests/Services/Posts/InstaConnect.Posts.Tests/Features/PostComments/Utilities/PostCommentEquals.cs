namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentEquals
{
	extension(PostComment entity)
	{
		public bool Matches(PostComment postComment)
		{
			return entity.Id.Matches(postComment.Id) &&
				   entity.UserId.Matches(postComment.UserId) &&
				   entity.Content == postComment.Content &&
				   entity.CreatedAtUtc == postComment.CreatedAtUtc &&
				   entity.UpdatedAtUtc == postComment.UpdatedAtUtc;
		}
	}

	extension(PostCommentId p)
	{
		public bool Matches(PostCommentId id)
		{
			return p.Matches(id.Id, id.CommentId);
		}

		public bool Matches(PostId id, string commentId)
		{
			return p.Matches(id.Id, commentId);
		}

		public bool Matches(string id, string commentId)
		{
			return p.Id.Matches(id) &&
				   p.CommentId.EqualsOrdinalIgnoreCase(commentId);
		}
	}
}
