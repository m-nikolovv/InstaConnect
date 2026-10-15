using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;
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
