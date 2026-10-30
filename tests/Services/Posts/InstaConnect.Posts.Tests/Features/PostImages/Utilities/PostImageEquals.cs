namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public static class PostImageEquals
{
	extension(PostImage entity)
	{
		public bool Matches(PostImage postImage)
		{
			return entity.Id.Matches(postImage.Id) &&
				   entity.Url.Matches(postImage.Url) &&
				   entity.CreatedAtUtc == postImage.CreatedAtUtc;
		}
	}

	extension(ICollection<PostImage> entities)
	{
		public bool Matches(ICollection<PostImage> postImages)
		{
			return entities.MatchesCollectionAndNotEmpty(
				postImages,
				e => e.Id,
				e => e.Id,
				(entity, postImage) => entity.Matches(postImage));
		}
	}

	extension(PostImageId p)
	{
		public bool Matches(PostImageId id)
		{
			return p.Matches(id.Id, id.ImageId);
		}

		public bool Matches(PostId id, string imageId)
		{
			return p.Matches(id.Id, imageId);
		}

		public bool Matches(string id, string imageId)
		{
			return p.Id.Matches(id) &&
				   p.ImageId.EqualsOrdinalIgnoreCase(imageId);
		}
	}
}
