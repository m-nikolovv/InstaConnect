using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Factories;

public class CreatePostCommentFactoryUnitTests : BasePostCommentDomainCommandUnitTest
{
	private readonly PostCommentFactory _factory;

	public CreatePostCommentFactoryUnitTests()
	{
		_factory = new(GuidProvider, DateTimeProvider);

		GuidProvider.SetupNewStringGuid(PostComment);
		DateTimeProvider.SetupGetOffsetUtcNow(PostComment);
	}

	[Fact]
	public void Create_ShouldCreatePostComment_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(PostCommentId.Id, PostComment.UserId, PostComment.Content);

		// Assert
		response.ShouldSatisfy(PostComment);
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(PostCommentId.Id, PostComment.UserId, PostComment.Content);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(PostCommentId.Id, PostComment.UserId, PostComment.Content);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
