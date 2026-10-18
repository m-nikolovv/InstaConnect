using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class DeleteChatMessageImageCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public DeleteChatMessageImageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(ChatMessageImage, CancellationToken);
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
}
