namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeEquals
{
	extension(PostLike entity)
	{
		public bool Matches(PostLike postLike)
		{
			return entity.Id.Matches(postLike.Id) &&
				   entity.CreatedAtUtc == postLike.CreatedAtUtc;
		}
	}

	extension(ICollection<PostLike> entities)
	{
		public bool Matches(ICollection<PostLike> postLikes)
		{
			return entities.MatchesCollectionAndNotEmpty(
				postLikes,
				e => e.Id,
				e => e.Id,
				(entity, postLike) => entity.Matches(postLike));
		}
	}

	extension(PostLikeId p)
	{
		public bool Matches(PostLikeId id)
		{
			return p.Matches(id.Id, id.UserId);
		}

		public bool Matches(PostId id, UserId userId)
		{
			return p.Matches(id.Id, userId.Id);
		}

		public bool Matches(string id, string userId)
		{
			return p.Id.Matches(id) &&
				   p.UserId.Matches(userId);
		}
	}
}
