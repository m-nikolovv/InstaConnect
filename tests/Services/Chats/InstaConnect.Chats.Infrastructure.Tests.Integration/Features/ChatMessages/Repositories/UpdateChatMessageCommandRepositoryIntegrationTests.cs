using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Repositories;

public class UpdateChatMessageCommandRepositoryIntegrationTests : BaseChatMessageInfrastructureCommandIntegrationTest
{
	public UpdateChatMessageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
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
}
