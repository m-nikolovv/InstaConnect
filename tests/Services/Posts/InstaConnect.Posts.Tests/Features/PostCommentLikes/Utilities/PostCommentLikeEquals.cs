using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

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

	extension(ICollection<PostCommentLike> entities)
	{
		public bool Matches(ICollection<PostCommentLike> postCommentLikes)
		{
			return entities.MatchesCollectionAndNotEmpty(
				postCommentLikes,
				e => e.Id,
				e => e.Id,
				(entity, postCommentLike) => entity.Matches(postCommentLike));
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

	extension(PostCommentLikeResponse? response)
	{
		public bool MatchesFull(UserId currentUserId, PostCommentLike? postCommentLike)
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment.MatchesFull(currentUserId, postCommentLike.PostComment);
		}

		public bool MatchesFull(string currentUserId, PostCommentLike? postCommentLike)
		{
			return response.MatchesFull(new UserId(currentUserId), postCommentLike);
		}

		public bool MatchesWithoutUser(UserId currentUserId, PostCommentLike? postCommentLike)
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User == null &&
				   response.PostComment.MatchesFull(currentUserId, postCommentLike.PostComment);
		}

		public bool MatchesWithoutUser(string currentUserId, PostCommentLike? postCommentLike)
		{
			return response.MatchesWithoutUser(new UserId(currentUserId), postCommentLike);
		}

		public bool MatchesWithoutPostComment(PostCommentLike? postCommentLike)
		{
			return response != null &&
				   postCommentLike != null &&
				   postCommentLike.Id.Matches(response.Id) &&
				   postCommentLike.CreatedAtUtc == response.CreatedAtUtc &&
				   response.User.MatchesFull(postCommentLike.User) &&
				   response.PostComment == null;
		}
	}
}
