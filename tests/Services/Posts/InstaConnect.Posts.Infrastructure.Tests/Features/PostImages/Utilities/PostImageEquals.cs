using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;

public static class PostImageEquals
{
	extension(PostImage p)
	{
		public bool Matches(
			PostImageId id,
			PostImage postImage)
		{
			return p.Matches(postImage);
		}
	}

	extension(ICollection<PostImage> p)
	{
		public bool Matches(
			ICollection<PostImageId> ids,
			ICollection<PostImage> postImages)
		{
			return p.Matches(postImages);
		}
	}

}
