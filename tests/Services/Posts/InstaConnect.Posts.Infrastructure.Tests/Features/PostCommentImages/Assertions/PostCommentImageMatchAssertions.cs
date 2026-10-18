using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;

public static class PostCommentImageMatchAssertions
{
	extension(PostCommentImage response)
	{
		public void ShouldSatisfy(PostCommentImageId id, PostCommentImage postCommentImage)
		{
			response.ShouldSatisfy(p => p.Matches(id, postCommentImage));
		}
	}

	extension(ICollection<PostCommentImage> response)
	{
		public void ShouldSatisfy(ICollection<PostCommentImageId> ids, ICollection<PostCommentImage> postCommentImages)
		{
			response.ShouldSatisfy(p => p.Matches(ids, postCommentImages));
		}
	}
}
