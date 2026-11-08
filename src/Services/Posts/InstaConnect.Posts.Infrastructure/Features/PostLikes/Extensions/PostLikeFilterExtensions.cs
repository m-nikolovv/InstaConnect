namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class PostLikeFilterExtensions
{
	extension(PostLikesFilterQuery filter)
	{
		public FilterDefinition<PostLike> GetFilter()
		{
			var id = filter.Id.GetFilterForIdEquals<PostLike>(p => p.Id.Id.Id);
			var userName = filter.UserName.GetFilterForNameStartsWith<PostLike>(p => p.User!.Name.Value);

			return Builders<PostLike>.Filter.AndAll(id, userName);
		}
	}

	extension(PostLikesForUserFilterQuery filter)
	{
		public FilterDefinition<PostLike> GetFilter()
		{
			return filter.UserId.GetFilterForIdEquals<PostLike>(p => p.Id.UserId.Id);
		}
	}

	extension(PostLikeId filter)
	{
		public FilterDefinition<PostLike> GetFilter()
		{
			return filter.GetFilterForIdEquals<PostLike>(p => p.Id.Id.Id, p => p.Id.UserId.Id);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> userIdField)
		{
			var id = filter.Id.GetFilterForIdEquals(idField);
			var userId = filter.UserId.GetFilterForIdEquals(userIdField);

			return Builders<T>.Filter.AndAll(id, userId);
		}
	}

	extension(IEnumerable<PostLikeId> filter)
	{
		public FilterDefinition<PostLike> GetFilter()
		{
			return filter.GetFilterForIdRange<PostLike>(p => p.Id.Id.Id, p => p.Id.UserId.Id);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> userIdField)
		{
			return Builders<T>.Filter.OrRange(filter.Select(item => item.GetFilterForIdEquals(idField, userIdField)));
		}
	}

	extension(IEnumerable<PostId> filter)
	{
		public FilterDefinition<PostLike> GetPostLikeCascadeFilter()
		{
			return filter.GetFilterForIdRange<PostLike>(p => p.Id.Id.Id);
		}
	}

	extension(UserId filter)
	{
		public FilterDefinition<PostLike> GetPostLikeCascadeFilter()
		{
			return filter.GetFilterForIdEquals<PostLike>(p => p.Id.UserId.Id);
		}
	}
}
