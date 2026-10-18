using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;

public class PostCommentImageIdBuilderFactory
{
	public PostCommentImageIdBuilder Create(PostCommentImageId id)
	{
		return new(id);
	}
}
