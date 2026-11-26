namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class PostCommentFilterExtensions
{
	extension(PostCommentsFilterQuery filter)
	{
		public FilterDefinition<PostComment> GetFilter()
		{
			var id = filter.Id.GetFilterForIdEquals<PostComment>(p => p.Id.Id.Id);
			var userName = filter.UserName.GetFilterForNameStartsWith<PostComment>(p => p.User!.Name.Value);

			return Builders<PostComment>.Filter.AndAll(id, userName);
		}
	}

	extension(PostCommentsForUserFilterQuery filter)
	{
		public FilterDefinition<PostComment> GetFilter()
		{
			return filter.UserId.GetFilterForIdEquals<PostComment>(p => p.UserId.Id);
		}
	}

	extension(PostCommentId filter)
	{
		public FilterDefinition<PostComment> GetFilter()
		{
			return filter.GetFilterForIdEquals<PostComment>(p => p.Id.Id.Id, p => p.Id.CommentId);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> commentIdField)
		{
			var id = filter.Id.GetFilterForIdEquals(idField);
			var commentId = Builders<T>.Filter.EqualsIgnoreCaseOrFalse(commentIdField, filter.CommentId);

			return Builders<T>.Filter.AndAll(id, commentId);
		}
	}

	extension(IEnumerable<PostCommentId> filter)
	{
		public FilterDefinition<PostComment> GetFilter()
		{
			return filter.GetFilterForIdRange<PostComment>(p => p.Id.Id.Id, p => p.Id.CommentId);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> commentIdField)
		{
			return Builders<T>.Filter.OrRange(filter.Select(item => item.GetFilterForIdEquals(idField, commentIdField)));
		}
	}

	extension(PostId filter)
	{
		public FilterDefinition<PostComment> GetPostCommentByParentFilter()
		{
			return filter.GetFilterForIdEquals<PostComment>(p => p.Id.Id.Id);
		}
	}

	extension(IEnumerable<PostId> filter)
	{
		public FilterDefinition<PostComment> GetPostCommentByParentFilter()
		{
			return filter.GetFilterForIdRange<PostComment>(p => p.Id.Id.Id);
		}
	}

	extension(UserId filter)
	{
		public FilterDefinition<PostComment> GetPostCommentByParentFilter()
		{
			return filter.GetFilterForIdEquals<PostComment>(p => p.UserId.Id);
		}
	}
}
