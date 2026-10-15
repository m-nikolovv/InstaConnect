using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Factories;

public class CreatePostLikeFactoryUnitTests : BasePostLikeDomainCommandUnitTest
{
	private readonly PostLikeFactory _factory;

	public CreatePostLikeFactoryUnitTests()
	{
		_factory = new(DateTimeProvider);

		DateTimeProvider.SetupGetOffsetUtcNow(PostLike);
	}

	[Fact]
	public void Create_ShouldCreatePostLike_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(PostLikeId.Id, PostLikeId.UserId);

		// Assert
		response.ShouldSatisfy(PostLike);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(PostLikeId.Id, PostLikeId.UserId);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
