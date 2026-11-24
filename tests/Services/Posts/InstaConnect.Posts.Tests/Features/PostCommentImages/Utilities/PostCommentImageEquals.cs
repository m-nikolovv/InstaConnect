using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageEquals
{
	extension(PostCommentImage entity)
	{
		public bool Matches(PostCommentImage postCommentImage)
		{
			return entity.Id.Matches(postCommentImage.Id) &&
				   entity.Url.Matches(postCommentImage.Url) &&
				   entity.CreatedAtUtc == postCommentImage.CreatedAtUtc;
		}
	}

	extension(ICollection<PostCommentImage> entities)
	{
		public bool Matches(ICollection<PostCommentImage> postCommentImages)
		{
			return entities.MatchesCollectionAndNotEmpty(
				postCommentImages,
				e => e.Id,
				e => e.Id,
				(entity, postCommentImage) => entity.Matches(postCommentImage));
		}
	}

	extension(PostCommentImageId p)
	{
		public bool Matches(PostCommentImageId id)
		{
			return p.Matches(id.Id, id.ImageId);
		}

		public bool Matches(PostCommentId id, string imageId)
		{
			return p.Id.Matches(id) &&
				   p.ImageId.EqualsOrdinalIgnoreCase(imageId);
		}
	}

	extension(PostCommentImageResponse? response)
	{
		public bool MatchesFull(PostCommentImage? postCommentImage)
		{
			return response != null &&
				   postCommentImage != null &&
				   postCommentImage.Id.Id.Matches(response.Id.Id) &&
				   postCommentImage.Id.ImageId.EqualsOrdinalIgnoreCase(response.Id.ImageId) &&
				   postCommentImage.Url.Matches(response.Url) &&
				   postCommentImage.CreatedAtUtc == response.CreatedAtUtc;
		}
	}

	extension(ICollection<PostCommentImageResponse> response)
	{
		public bool MatchesFull(ICollection<PostCommentImage> postCommentImages)
		{
			return response.MatchesCollectionAndNotEmpty(
				postCommentImages,
				r => r.Id,
				p => p.Id,
				(r, p) => r.MatchesFull(p));
		}
	}
}
