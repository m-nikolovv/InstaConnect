using InstaConnect.Posts.Application.Features.PostImages.Models;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostImages.Utilities;

public static class PostImageMapper
{
	extension(PostImage postImage)
	{
		internal PostImageQueryResponse ToFullQueryResponse()
		{
			return new(
				postImage.Id.Id.Id,
				postImage.Id.ImageId,
				postImage.Url.Value,
				postImage.CreatedAtUtc);
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		internal ICollection<PostImageQueryResponse> ToFullQueryResponse()
		{
			return [.. postImages.Select(postImage => postImage.ToFullQueryResponse())];
		}
	}
}
