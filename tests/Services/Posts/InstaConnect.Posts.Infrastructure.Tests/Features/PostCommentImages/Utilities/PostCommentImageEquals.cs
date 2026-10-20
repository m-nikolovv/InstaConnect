using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageEquals
{
	extension(PostCommentImage p)
	{
		public bool Matches(
			PostCommentImageId id,
			PostCommentImage postCommentImage)
		{
			return p.Matches(postCommentImage);
		}
	}

	extension(ICollection<PostCommentImage> p)
	{
		public bool Matches(
			ICollection<PostCommentImageId> ids,
			ICollection<PostCommentImage> postCommentImages)
		{
			return p.Matches(postCommentImages);
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
			return response.MatchesCollection(
				postCommentImages,
				r => r.Id,
				p => p.Id,
				(r, p) => r.MatchesFull(p));
		}
	}
}
