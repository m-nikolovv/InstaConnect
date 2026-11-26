using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

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

	extension(PostImageResponse? response)
	{
		public bool MatchesFull(PostImage? postImage)
		{
			return response != null &&
				   postImage != null &&
				   postImage.Id.Id.Matches(response.Id.Id) &&
				   postImage.Id.ImageId.EqualsOrdinalIgnoreCase(response.Id.ImageId) &&
				   postImage.Url.Matches(response.Url) &&
				   postImage.CreatedAtUtc == response.CreatedAtUtc;
		}
	}

	extension(ICollection<PostImageResponse> response)
	{
		public bool MatchesFull(ICollection<PostImage> postImages)
		{
			return response.MatchesCollectionAndNotEmpty(
				postImages,
				r => r.Id,
				p => p.Id,
				(r, p) => r.MatchesFull(p));
		}
	}
}
