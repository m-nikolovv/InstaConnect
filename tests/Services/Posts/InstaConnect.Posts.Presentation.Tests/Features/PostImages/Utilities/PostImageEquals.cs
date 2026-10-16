using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Presentation.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostImages.Utilities;

public static class PostImageEquals
{
	extension(PostImageApiResponse? response)
	{
		public bool MatchesFull(PostImage? postImage)
		{
			return response != null &&
				   postImage != null &&
				   postImage.Id.Id.Matches(response.Id) &&
				   postImage.Id.ImageId.EqualsOrdinalIgnoreCase(response.ImageId) &&
				   postImage.Url.Matches(response.Url) &&
				   postImage.CreatedAtUtc == response.CreatedAtUtc;
		}
	}

	extension(ICollection<PostImageApiResponse> response)
	{
		public bool MatchesFull(ICollection<PostImage> postImages)
		{
			return response.MatchesCollection(
				postImages,
				r => new(new(r.Id), r.ImageId),
				p => p.Id,
				(r, p) => r.MatchesFull(p));
		}
	}
}
