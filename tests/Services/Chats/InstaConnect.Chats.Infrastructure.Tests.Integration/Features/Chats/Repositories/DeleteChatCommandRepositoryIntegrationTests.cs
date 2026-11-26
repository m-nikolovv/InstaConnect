using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class DeleteChatCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	public DeleteChatCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeDeleteAsync(Chat, CurrentUserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeDeleteAsync(Chat, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChat_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		chat.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedChat_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var cachedChat = await ServiceScope.GetChatCacheByIdAsync(Chat, CurrentUserId, CancellationToken);

		// Assert
		cachedChat.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatChatMessages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var chatChatMessages = await ServiceScope.GetByIdRangeAsync(ChatChatMessageIds, CancellationToken);

		// Assert
		chatChatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatChatMessagesChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var chatChatMessagesChatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatChatMessagesChatMessageImageIds, CancellationToken);

		// Assert
		chatChatMessagesChatMessageImages.ShouldBeEmpty();
	}
}
