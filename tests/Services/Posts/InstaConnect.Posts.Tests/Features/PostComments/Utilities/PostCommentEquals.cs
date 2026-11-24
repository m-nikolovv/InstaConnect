using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

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

	extension(ICollection<PostComment> entities)
	{
		public bool Matches(ICollection<PostComment> postComments)
		{
			return entities.MatchesCollectionAndNotEmpty(
				postComments,
				e => e.Id,
				e => e.Id,
				(entity, postComment) => entity.Matches(postComment));
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

	extension(PostCommentResponse? response)
	{
		public bool MatchesFull(UserId currentUserId, PostComment? postComment)
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)) &&
				   response.LikeCount == postComment.PostCommentLikes.Count &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post.MatchesFull(currentUserId, postComment.Post);
		}

		public bool MatchesFull(string currentUserId, PostComment? postComment)
		{
			return response.MatchesFull(new UserId(currentUserId), postComment);
		}

		public bool MatchesWithoutPost(UserId currentUserId, PostComment? postComment)
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)) &&
				   response.LikeCount == postComment.PostCommentLikes.Count &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(postComment.User) &&
				   response.Post == null;
		}

		public bool MatchesWithoutPost(string currentUserId, PostComment? postComment)
		{
			return response.MatchesWithoutPost(new UserId(currentUserId), postComment);
		}

		public bool MatchesWithoutUser(UserId currentUserId, PostComment? postComment)
		{
			return response != null &&
				   postComment != null &&
				   postComment.Id.Matches(response.Id) &&
				   postComment.UserId.Matches(response.UserId) &&
				   postComment.Content == response.Content &&
				   postComment.Summary.Matches(response.Summary) &&
				   response.PostCommentImages.MatchesFull(postComment.PostCommentImages) &&
				   response.IsLikedByCurrentUser == postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)) &&
				   response.LikeCount == postComment.PostCommentLikes.Count &&
				   postComment.CreatedAtUtc == response.CreatedAtUtc &&
				   postComment.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null &&
				   response.Post.MatchesFull(currentUserId, postComment.Post);
		}

		public bool MatchesWithoutUser(string currentUserId, PostComment? postComment)
		{
			return response.MatchesWithoutUser(new UserId(currentUserId), postComment);
		}
	}
}
