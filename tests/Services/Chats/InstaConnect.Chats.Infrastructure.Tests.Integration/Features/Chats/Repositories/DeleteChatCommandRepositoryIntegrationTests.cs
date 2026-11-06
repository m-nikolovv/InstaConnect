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
		await ServiceScope.AddRangeAsync(ChatChatMessages, CancellationToken);
		await ServiceScope.AddRangeAsync(ChatChatMessageImages, CancellationToken);
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
		var chatMessages = await ServiceScope.GetByIdRangeAsync(ChatChatMessageIds, CancellationToken);

		// Assert
		chatMessages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteChatChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Chat, CancellationToken);
		var chatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatChatMessageImageIds, CancellationToken);

		// Assert
		chatMessageImages.ShouldBeEmpty();
	}
}
