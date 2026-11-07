namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class DeleteChatCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	public DeleteChatCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
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
