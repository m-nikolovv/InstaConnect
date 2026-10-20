using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;

public static class PostImageMapper
{
	extension(PostImage postImage)
	{
		internal PostImageResponse ToFullResponse()
		{
			return new(
				postImage.Id,
				postImage.Url,
				postImage.CreatedAtUtc);
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		internal ICollection<PostImageResponse> ToFullResponse()
		{
			return [.. postImages.Select(postImage => postImage.ToFullResponse())];
		}
	}
}
