using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class DeleteRangeChatMessageImagesCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public DeleteRangeChatMessageImagesCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ChatMessageImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldDeleteChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteRangeAsync(ChatMessageImages, CancellationToken);
		var chatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatMessageImageIds, CancellationToken);

		// Assert
		chatMessageImages.ShouldBeEmpty();
	}
}
