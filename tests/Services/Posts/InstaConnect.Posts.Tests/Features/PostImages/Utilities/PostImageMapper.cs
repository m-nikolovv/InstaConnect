using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public static class PostImageMapper
{
	extension(PostImage postImage)
	{
		public PostImageResponse ToFullResponse()
		{
			return new(
				postImage.Id,
				postImage.Url,
				postImage.CreatedAtUtc);
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		public ICollection<PostImageResponse> ToFullResponse()
		{
			return [.. postImages.Select(postImage => postImage.ToFullResponse())];
		}
	}
}
