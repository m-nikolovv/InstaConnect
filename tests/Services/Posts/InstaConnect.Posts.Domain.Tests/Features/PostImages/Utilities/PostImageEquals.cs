using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostImages.Utilities;

public static class PostImageEquals
{
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
			return response.MatchesCollection(
				postImages,
				r => r.Id,
				p => p.Id,
				(r, p) => r.MatchesFull(p));
		}
	}
}
