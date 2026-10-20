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
}
