using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostEquals
{
	extension(Post entity)
	{
		public bool Matches(Post post)
		{
			return entity.Id.Matches(post.Id) &&
				   entity.UserId.Matches(post.UserId) &&
				   entity.Title == post.Title &&
				   entity.Content == post.Content &&
				   entity.CreatedAtUtc == post.CreatedAtUtc &&
				   entity.UpdatedAtUtc == post.UpdatedAtUtc;
		}
	}

	extension(ICollection<Post> entities)
	{
		public bool Matches(ICollection<Post> posts)
		{
			return entities.MatchesCollectionAndNotEmpty(
				posts,
				e => e.Id,
				e => e.Id,
				(entity, post) => entity.Matches(post));
		}
	}

	extension(PostId p)
	{
		public bool Matches(PostId id)
		{
			return p.Matches(id.Id);
		}

		public bool Matches(string id)
		{
			return p.Id.EqualsOrdinalIgnoreCase(id);
		}
	}

	extension(PostResponse? response)
	{
		public bool MatchesFull(UserId currentUserId, Post? post)
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   post.Summary.Matches(response.Summary) &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)) &&
				   response.LikeCount == post.PostLikes.Count &&
				   response.CommentCount == post.PostComments.Count &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User.MatchesFull(post.User);
		}

		public bool MatchesFull(string currentUserId, Post? post)
		{
			return response.MatchesFull(new UserId(currentUserId), post);
		}

		public bool MatchesWithoutUser(UserId currentUserId, Post? post)
		{
			return response != null &&
				   post != null &&
				   post.Id.Matches(response.Id) &&
				   post.UserId.Matches(response.UserId) &&
				   post.Title == response.Title &&
				   post.Content == response.Content &&
				   post.Summary.Matches(response.Summary) &&
				   response.PostImages.MatchesFull(post.PostImages) &&
				   response.IsLikedByCurrentUser == post.PostLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)) &&
				   response.LikeCount == post.PostLikes.Count &&
				   response.CommentCount == post.PostComments.Count &&
				   post.CreatedAtUtc == response.CreatedAtUtc &&
				   post.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.User == null;
		}

		public bool MatchesWithoutUser(string currentUserId, Post? post)
		{
			return response.MatchesWithoutUser(new UserId(currentUserId), post);
		}
	}
}
