using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;
using InstaConnect.Posts.Presentation.Features.PostCommentImages.Models.Responses;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageEquals
{
	extension(PostCommentImageApiResponse? response)
	{
		public bool MatchesFull(PostCommentImage? postCommentImage)
		{
			return response != null &&
				   postCommentImage != null &&
				   postCommentImage.Id.Id.Matches(response.Id, response.CommentId) &&
				   postCommentImage.Id.ImageId.EqualsOrdinalIgnoreCase(response.ImageId) &&
				   postCommentImage.Url.Matches(response.Url) &&
				   postCommentImage.CreatedAtUtc == response.CreatedAtUtc;
		}
	}

	extension(ICollection<PostCommentImageApiResponse> response)
	{
		public bool MatchesFull(ICollection<PostCommentImage> postCommentImages)
		{
			return response.MatchesCollection(
				postCommentImages,
				r => new(new(new(r.Id), r.CommentId), r.ImageId),
				p => p.Id,
				(r, p) => r.MatchesFull(p));
		}
	}
}
