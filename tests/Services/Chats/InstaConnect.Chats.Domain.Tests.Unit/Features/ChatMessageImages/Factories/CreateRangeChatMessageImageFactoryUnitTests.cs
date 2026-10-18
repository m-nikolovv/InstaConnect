using InstaConnect.Chats.Domain.Features.ChatMessageImages.Helpers;
using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Entities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Assertions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessageImages.Factories;

public class CreateRangeChatMessageImageFactoryUnitTests : BaseChatMessageImageDomainCommandUnitTest
{
	private readonly ICollection<Url> _urls;
	private readonly ICollection<ChatMessageImage> _chatMessageImages;

	private readonly ChatMessageImageFactory _factory;

	public CreateRangeChatMessageImageFactoryUnitTests()
	{
		_urls = [ChatMessageImage.Url];
		_chatMessageImages = [ChatMessageImage];

		_factory = new(GuidProvider, DateTimeProvider);

		GuidProvider.SetupNewStringGuid(ChatMessageImageId.ImageId);
		DateTimeProvider.SetupGetOffsetUtcNow(ChatMessageImage.CreatedAtUtc);
	}

	[Fact]
	public void CreateRange_ShouldCreateChatMessageImages_WhenRequestIsValid()
	{
		// Act
		var response = _factory.CreateRange(ChatMessageId, _urls);

		// Assert
		response.ShouldSatisfy(_chatMessageImages);
	}

	[Fact]
	public void CreateRange_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.CreateRange(ChatMessageId, _urls);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void CreateRange_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.CreateRange(ChatMessageId, _urls);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
