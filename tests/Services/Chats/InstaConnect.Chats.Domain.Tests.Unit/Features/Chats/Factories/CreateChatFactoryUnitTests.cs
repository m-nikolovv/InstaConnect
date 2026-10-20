using InstaConnect.Chats.Domain.Features.Chats.Helpers;
using InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Common.Domain.Tests.Features.Assertions;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Factories;

public class CreateChatFactoryUnitTests : BaseChatDomainCommandUnitTest
{
	private readonly ChatFactory _factory;

	public CreateChatFactoryUnitTests()
	{
		_factory = new(DateTimeProvider);

		DateTimeProvider.SetupGetOffsetUtcNow(Chat);
	}

	[Fact]
	public void Create_ShouldCreateChat_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(ChatId.ParticipantOneId, ChatId.ParticipantTwoId);

		// Assert
		response.ShouldSatisfy(Chat);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(ChatId.ParticipantOneId, ChatId.ParticipantTwoId);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
