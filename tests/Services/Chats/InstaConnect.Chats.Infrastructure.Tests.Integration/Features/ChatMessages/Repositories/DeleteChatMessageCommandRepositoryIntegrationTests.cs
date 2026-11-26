using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class DeleteChatMessageCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public DeleteChatMessageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteChatMessageAsync(
			ParticipantOne,
			ParticipantTwo,
			Chat,
			ChatMessage,
			ChatMessageChatMessageImages,
			CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedChatMessage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessage, CancellationToken);
		var cachedChatMessage = await ServiceScope.GetChatMessageCacheByIdAsync(ChatMessage, CancellationToken);

		// Assert
		cachedChatMessage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedChat_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessage, CancellationToken);
		var cachedChat = await ServiceScope.GetChatCacheByIdAsync(ChatMessage, CancellationToken);

		// Assert
		cachedChat.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessageChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessage, CancellationToken);
		var chatMessageChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatMessageChatMessageImageIds, CancellationToken);

		// Assert
		chatMessageChatMessageImages.ShouldBeEmpty();
	}
}
