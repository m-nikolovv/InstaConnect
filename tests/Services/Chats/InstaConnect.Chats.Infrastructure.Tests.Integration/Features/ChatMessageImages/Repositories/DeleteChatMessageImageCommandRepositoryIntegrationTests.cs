using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class DeleteChatMessageImageCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public DeleteChatMessageImageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeDeleteAsync(ChatMessageImage, CurrentUserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeDeleteAsync(ChatMessageImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatMessageImage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessageImage, CancellationToken);
		var chatMessageImage = await ServiceScope.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		chatMessageImage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedChatMessage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(ChatMessageImage, CancellationToken);
		var cachedChatMessage = await ServiceScope.GetChatMessageCacheByIdAsync(ChatMessage, CurrentUserId, CancellationToken);

		// Assert
		cachedChatMessage.ShouldBeNull();
	}
}
