using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class AddChatMessageCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public AddChatMessageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupAddAsync(ChatMessage, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(ChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(ChatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldDeleteCachedChat_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(ChatMessage, CancellationToken);
		var cachedChat = await ServiceScope.GetChatCacheByIdAsync(ChatMessage, CancellationToken);

		// Assert
		cachedChat.ShouldBeNull();
	}
}
