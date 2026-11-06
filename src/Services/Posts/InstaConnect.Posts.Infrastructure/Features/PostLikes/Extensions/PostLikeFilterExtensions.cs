namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class PostLikeFilterExtensions
{
	extension(PostLikesFilterQuery filter)
	{
		public FilterDefinition<PostLike> GetFilter()
		{
			var id = filter.Id.GetFilterForIdEquals<PostLike>(p => p.Id.Id.Id);
			var userName = filter.UserName.GetFilterForNameStartsWith<PostLike>(p => p.User!.Name.Value);

			return Builders<PostLike>.Filter.And(id, userName);
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

			return Builders<T>.Filter.And(id, userId);
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
