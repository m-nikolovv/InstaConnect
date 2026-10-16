using InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Assertions;

public static class PostImageMatchAssertions
{
	extension(PostImage response)
	{
		public void ShouldSatisfy(PostImageId id, PostImage postImage)
		{
			response.ShouldSatisfy(p => p.Matches(id, postImage));
		}
	}

	extension(ICollection<PostImage> response)
	{
		public void ShouldSatisfy(ICollection<PostImageId> ids, ICollection<PostImage> postImages)
		{
			response.ShouldSatisfy(p => p.Matches(ids, postImages));
		}
	}
}
