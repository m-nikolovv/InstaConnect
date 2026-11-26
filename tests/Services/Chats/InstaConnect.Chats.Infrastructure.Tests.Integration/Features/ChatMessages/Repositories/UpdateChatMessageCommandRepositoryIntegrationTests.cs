using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class UpdateChatMessageCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public UpdateChatMessageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupUpdateAsync(ChatMessage, UserId, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateChatMessage_WhenCommandIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilderFactory.Create(Chat).WithMessageId(ChatMessageId).Build();

		// Act
		await Repository.UpdateAsync(updatedChatMessage, CancellationToken);
		var chatMessage = await ServiceScope.GetByIdAsync(ChatMessageId, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(updatedChatMessage);
	}

	[Fact]
	public async Task UpdateAsync_ShouldDeleteCachedChatMessage_WhenCommandIsValid()
	{
		// Arrange
		var updatedChatMessage = ChatMessageBuilderFactory.Create(Chat).WithMessageId(ChatMessageId).Build();

		// Act
		await Repository.UpdateAsync(updatedChatMessage, CancellationToken);
		var cachedChatMessage = await ServiceScope.GetChatMessageCacheByIdAsync(updatedChatMessage, UserId, CancellationToken);

		// Assert
		cachedChatMessage.ShouldBeNull();
	}
}
