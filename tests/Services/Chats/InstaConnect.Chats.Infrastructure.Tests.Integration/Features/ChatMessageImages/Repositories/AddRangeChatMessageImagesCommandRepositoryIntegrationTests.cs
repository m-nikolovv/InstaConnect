using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class AddRangeChatMessageImagesCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public AddRangeChatMessageImagesCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupAddAsync(ChatMessageImage, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldAddChatMessageImages_WhenCommandIsValid()
	{
		// Act
		await Repository.AddRangeAsync(ChatMessageImages, CancellationToken);
		var chatMessageImages = await ServiceScope.GetByIdRangeAsync(ChatMessageImageIds, CancellationToken);

		// Assert
		chatMessageImages.ShouldSatisfy(ChatMessageImages);
	}
}
