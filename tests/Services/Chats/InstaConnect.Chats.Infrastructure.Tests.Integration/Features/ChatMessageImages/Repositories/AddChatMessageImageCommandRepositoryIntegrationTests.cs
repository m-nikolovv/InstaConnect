using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class AddChatMessageImageCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public AddChatMessageImageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupAddChatMessageImageAsync(
			ParticipantOne,
			ParticipantTwo,
			Chat,
			ChatMessage,
			CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessageImage_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(ChatMessageImage, CancellationToken);
		var chatMessageImage = await ServiceScope.GetByIdAsync(ChatMessageImageId, CancellationToken);

		// Assert
		chatMessageImage.ShouldSatisfy(ChatMessageImage);
	}

	[Fact]
	public async Task AddAsync_ShouldDeleteCachedChatMessage_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(ChatMessageImage, CancellationToken);
		var cachedChatMessage = await ServiceScope.GetChatMessageCacheByIdAsync(ChatMessage, CancellationToken);

		// Assert
		cachedChatMessage.ShouldBeNull();
	}
}
