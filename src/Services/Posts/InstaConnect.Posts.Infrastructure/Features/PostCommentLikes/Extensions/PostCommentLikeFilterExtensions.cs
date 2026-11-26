namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class PostCommentLikeFilterExtensions
{
	extension(PostCommentLikesFilterQuery filter)
	{
		public FilterDefinition<PostCommentLike> GetFilter()
		{
			var commentId = filter.CommentId.GetFilterForIdEquals<PostCommentLike>(p => p.Id.CommentId.Id.Id, p => p.Id.CommentId.CommentId);
			var userName = filter.UserName.GetFilterForNameStartsWith<PostCommentLike>(p => p.User!.Name.Value);

			return Builders<PostCommentLike>.Filter.AndAll(commentId, userName);
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

			return Builders<T>.Filter.AndAll(commentId, userId);
		}
	}

	extension(IEnumerable<PostCommentLikeId> filter)
	{
		public FilterDefinition<PostCommentLike> GetFilter()
		{
			return filter.GetFilterForIdRange<PostCommentLike>(
				p => p.Id.CommentId.Id.Id, p => p.Id.CommentId.CommentId, p => p.Id.UserId.Id);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> commentIdField,
			Expression<Func<T, object>> userIdField)
		{
			return Builders<T>.Filter.OrRange(filter.Select(item => item.GetFilterForIdEquals(idField, commentIdField, userIdField)));
		}
	}

	extension(PostCommentId filter)
	{
		public FilterDefinition<PostCommentLike> GetPostCommentLikeByParentFilter()
		{
			return filter.GetFilterForIdEquals<PostCommentLike>(p => p.Id.CommentId.Id.Id, p => p.Id.CommentId.CommentId);
		}
	}

	extension(IEnumerable<PostCommentId> filter)
	{
		public FilterDefinition<PostCommentLike> GetPostCommentLikeByParentFilter()
		{
			return filter.GetFilterForIdRange<PostCommentLike>(p => p.Id.CommentId.Id.Id, p => p.Id.CommentId.CommentId);
		}
	}

	extension(UserId filter)
	{
		public FilterDefinition<PostCommentLike> GetPostCommentLikeByParentFilter()
		{
			return filter.GetFilterForIdEquals<PostCommentLike>(p => p.Id.UserId.Id);
		}
	}
}
