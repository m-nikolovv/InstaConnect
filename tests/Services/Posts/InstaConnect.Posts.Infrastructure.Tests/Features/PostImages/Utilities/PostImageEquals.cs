using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;

public static class PostImageEquals
{
	extension(PostImage p)
	{
		public bool Matches(
			PostImageId id,
			PostImage postImage)
		{
			return p.Matches(postImage);
		}
	}

	extension(ICollection<PostImage> p)
	{
		public bool Matches(
			ICollection<PostImageId> ids,
			ICollection<PostImage> postImages)
		{
			return p.Matches(postImages);
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
