namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class PostFilterExtensions
{
	extension(PostsFilterQuery filter)
	{
		public FilterDefinition<Post> GetFilter()
		{
			var userName = filter.UserName.GetFilterForNameStartsWith<Post>(p => p.User!.Name.Value);
			var title = Builders<Post>.Filter.StartsWithIgnoreCase(
				p => p.Title, filter.Title);

			return Builders<Post>.Filter.AndAll(userName, title);
		}
	}

	extension(PostsForUserFilterQuery filter)
	{
		public FilterDefinition<Post> GetFilter()
		{
			var userId = filter.UserId.GetFilterForIdEquals<Post>(p => p.UserId.Id);
			var title = Builders<Post>.Filter.StartsWithIgnoreCase(
				p => p.Title, filter.Title);

			return Builders<Post>.Filter.AndAll(userId, title);
		}
	}

	extension(PostId filter)
	{
		public FilterDefinition<Post> GetFilter()
		{
			return filter.GetFilterForIdEquals<Post>(p => p.Id.Id);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(Expression<Func<T, object>> idField)
		{
			return Builders<T>.Filter.EqualsIgnoreCaseOrFalse(idField, filter.Id);
		}
	}

	extension(IEnumerable<PostId> filter)
	{
		public FilterDefinition<Post> GetFilter()
		{
			return filter.GetFilterForIdRange<Post>(p => p.Id.Id);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(Expression<Func<T, object>> idField)
		{
			return Builders<T>.Filter.InRange(idField, filter.Select(item => item.Id));
		}
	}

	extension(UserId filter)
	{
		public FilterDefinition<Post> GetPostCascadeFilter()
		{
			return filter.GetFilterForIdEquals<Post>(p => p.UserId.Id);
		}
	}
}
