
namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class DeleteRangeChatMessageImagesCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public DeleteRangeChatMessageImagesCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupGetAllAsync(ChatMessageImages, CancellationToken);
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
