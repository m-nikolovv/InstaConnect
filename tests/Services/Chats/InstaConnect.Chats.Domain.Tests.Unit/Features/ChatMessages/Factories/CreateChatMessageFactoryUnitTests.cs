using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Common.Domain.Tests.Features.Assertions;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Factories;

public class CreateChatMessageFactoryUnitTests : BaseChatMessageDomainCommandUnitTest
{
	private readonly ChatMessageFactory _factory;

	public CreateChatMessageFactoryUnitTests()
	{
		_factory = new(GuidProvider, DateTimeProvider);

		GuidProvider.SetupNewStringGuid(ChatMessage);
		DateTimeProvider.SetupGetOffsetUtcNow(ChatMessage);
	}

	[Fact]
	public void Create_ShouldCreateChatMessage_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(ChatMessageId.Id, ChatMessage.SenderId, ChatMessage.Content);

		// Assert
		response.ShouldSatisfy(ChatMessage);
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(ChatMessageId.Id, ChatMessage.SenderId, ChatMessage.Content);

		// Assert
		GuidProvider.ShouldHaveReceivedOneNewStringGuid();
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(ChatMessageId.Id, ChatMessage.SenderId, ChatMessage.Content);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
