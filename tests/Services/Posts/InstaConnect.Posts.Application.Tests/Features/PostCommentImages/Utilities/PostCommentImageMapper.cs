using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageMapper
{
	extension(PostCommentImage postCommentImage)
	{
		internal PostCommentImageResponse ToFullResponse()
		{
			return new(
				postCommentImage.Id,
				postCommentImage.Url,
				postCommentImage.CreatedAtUtc);
		}
	}

	extension(ICollection<PostCommentImage> postCommentImages)
	{
		internal ICollection<PostCommentImageResponse> ToFullResponse()
		{
			return [.. postCommentImages.Select(postCommentImage => postCommentImage.ToFullResponse())];
		}
	}
}
