using InstaConnect.Posts.Application.Features.PostCommentImages.Models;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageMapper
{
	extension(PostCommentImage postCommentImage)
	{
		internal PostCommentImageQueryResponse ToFullQueryResponse()
		{
			return new(
				postCommentImage.Id.Id.Id.Id,
				postCommentImage.Id.Id.CommentId,
				postCommentImage.Id.ImageId,
				postCommentImage.Url.Value,
				postCommentImage.CreatedAtUtc);
		}
	}

	extension(ICollection<PostCommentImage> postCommentImages)
	{
		internal ICollection<PostCommentImageQueryResponse> ToFullQueryResponse()
		{
			return [.. postCommentImages.Select(postCommentImage => postCommentImage.ToFullQueryResponse())];
		}
	}
}
