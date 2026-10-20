using InstaConnect.Chats.Tests.Features.ChatMessageImages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class AddChatMessageImageCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public AddChatMessageImageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
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
}
