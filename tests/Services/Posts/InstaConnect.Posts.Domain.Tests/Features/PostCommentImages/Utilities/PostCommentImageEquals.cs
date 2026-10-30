using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageEquals
{
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
