using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageEquals
{
	extension(PostCommentImage p)
	{
		public bool Matches(
			PostCommentImageId id,
			PostCommentImage postCommentImage)
		{
			return p.Matches(postCommentImage);
		}
	}

	extension(ICollection<PostCommentImage> p)
	{
		public bool Matches(
			ICollection<PostCommentImageId> ids,
			ICollection<PostCommentImage> postCommentImages)
		{
			return p.Matches(postCommentImages);
		}
	}

}
