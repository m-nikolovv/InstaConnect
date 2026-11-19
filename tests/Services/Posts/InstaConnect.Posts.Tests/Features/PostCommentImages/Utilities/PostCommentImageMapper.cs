using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageMapper
{
	extension(PostCommentImage postCommentImage)
	{
		public PostCommentImageResponse ToFullResponse()
		{
			return new(
				postCommentImage.Id,
				postCommentImage.Url,
				postCommentImage.CreatedAtUtc);
		}
	}

	extension(ICollection<PostCommentImage> postCommentImages)
	{
		public ICollection<PostCommentImageResponse> ToFullResponse()
		{
			return [.. postCommentImages.Select(postCommentImage => postCommentImage.ToFullResponse())];
		}
	}
}
