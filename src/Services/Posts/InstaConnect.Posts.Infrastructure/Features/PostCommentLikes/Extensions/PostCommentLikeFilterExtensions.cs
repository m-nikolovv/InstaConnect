using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class PostCommentLikeFilterExtensions
{
	extension(PostCommentLikesFilterQuery filter)
	{
		public FilterDefinition<PostCommentLike> GetFilter()
		{
			var commentId = filter.CommentId.GetFilterForIdEquals<PostCommentLike>(p => p.Id.CommentId.Id.Id, p => p.Id.CommentId.CommentId);
			var userName = filter.UserName.GetFilterForNameStartsWith<PostCommentLike>(p => p.User!.Name.Value);

			return Builders<PostCommentLike>.Filter.And(commentId, userName);
		}
	}

	extension(PostCommentLikesForUserFilterQuery filter)
	{
		public FilterDefinition<PostCommentLike> GetFilter()
		{
			return filter.UserId.GetFilterForIdEquals<PostCommentLike>(p => p.Id.UserId.Id);
		}
	}

	extension(PostCommentLikeId filter)
	{
		public FilterDefinition<PostCommentLike> GetFilter()
		{
			return filter.GetFilterForIdEquals<PostCommentLike>(
				p => p.Id.CommentId.Id.Id, p => p.Id.CommentId.CommentId, p => p.Id.UserId.Id);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> commentIdField,
			Expression<Func<T, object>> userIdField)
		{
			var commentId = filter.CommentId.GetFilterForIdEquals(idField, commentIdField);
			var userId = filter.UserId.GetFilterForIdEquals(userIdField);

			return Builders<T>.Filter.And(commentId, userId);
		}
	}
}
