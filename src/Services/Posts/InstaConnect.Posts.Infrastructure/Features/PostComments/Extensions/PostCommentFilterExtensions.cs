namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

internal static class PostCommentFilterExtensions
{
	extension(PostCommentsFilterQuery filter)
	{
		public FilterDefinition<PostComment> GetFilter()
		{
			var id = filter.Id.GetFilterForIdEquals<PostComment>(p => p.Id.Id.Id);
			var userName = filter.UserName.GetFilterForNameStartsWith<PostComment>(p => p.User!.Name.Value);

			return Builders<PostComment>.Filter.And(id, userName);
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
			var commentId = Builders<T>.Filter.EqualsIgnoreCase(
				commentIdField, filter.CommentId, filter.CommentId.IsNullOrEmptyOrWhiteSpace());

			return Builders<T>.Filter.And(id, commentId);
		}
	}
}
