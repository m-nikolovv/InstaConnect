using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentImages.Factories;

public class CreateRangePostCommentImageFactoryUnitTests : BasePostCommentImageDomainCommandUnitTest
{
	private readonly ICollection<Url> _urls;
	private readonly ICollection<PostCommentImage> _postCommentImages;

	private readonly PostCommentImageFactory _factory;

	public CreateRangePostCommentImageFactoryUnitTests()
	{
		_urls = [PostCommentImage.Url];
		_postCommentImages = [PostCommentImage];

		_factory = new(GuidProvider, DateTimeProvider);

		GuidProvider.SetupNewStringGuid(PostCommentImageId.ImageId);
		DateTimeProvider.SetupGetOffsetUtcNow(PostCommentImage.CreatedAtUtc);
	}

	[Fact]
	public void CreateRange_ShouldCreatePostCommentImages_WhenRequestIsValid()
	{
		// Act
		var response = _factory.CreateRange(PostCommentId, _urls);

		// Assert
		response.ShouldSatisfy(_postCommentImages);
	}

	[Fact]
	public void CreateRange_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.CreateRange(PostCommentId, _urls);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void CreateRange_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.CreateRange(PostCommentId, _urls);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
