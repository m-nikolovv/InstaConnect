using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Posts.Domain.Features.PostImages.Helpers;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostImages.Factories;

public class CreateRangePostImageFactoryUnitTests : BasePostImageDomainCommandUnitTest
{
	private readonly ICollection<Url> _urls;
	private readonly ICollection<PostImage> _postImages;

	private readonly PostImageFactory _factory;

	public CreateRangePostImageFactoryUnitTests()
	{
		_urls = [PostImage.Url];
		_postImages = [PostImage];

		_factory = new(GuidProvider, DateTimeProvider);

		GuidProvider.SetupNewStringGuid(PostImageId.ImageId);
		DateTimeProvider.SetupGetOffsetUtcNow(PostImage.CreatedAtUtc);
	}

	[Fact]
	public void CreateRange_ShouldCreatePostImages_WhenRequestIsValid()
	{
		// Act
		var response = _factory.CreateRange(PostId, _urls);

		// Assert
		response.ShouldSatisfy(_postImages);
	}

	[Fact]
	public void CreateRange_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.CreateRange(PostId, _urls);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void CreateRange_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.CreateRange(PostId, _urls);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
