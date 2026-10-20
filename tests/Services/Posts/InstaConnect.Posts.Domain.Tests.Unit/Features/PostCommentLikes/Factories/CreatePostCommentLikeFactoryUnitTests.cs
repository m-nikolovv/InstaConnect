using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Factories;

public class CreatePostCommentLikeFactoryUnitTests : BasePostCommentLikeDomainCommandUnitTest
{
	private readonly PostCommentLikeFactory _factory;

	public CreatePostCommentLikeFactoryUnitTests()
	{
		_factory = new(DateTimeProvider);

		DateTimeProvider.SetupGetOffsetUtcNow(PostCommentLike);
	}

	[Fact]
	public void Create_ShouldCreatePostCommentLike_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(PostCommentLikeId.CommentId, PostCommentLikeId.UserId);

		// Assert
		response.ShouldSatisfy(PostCommentLike);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(PostCommentLikeId.CommentId, PostCommentLikeId.UserId);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
