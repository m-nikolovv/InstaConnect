using InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Repositories;

public class AddRangeChatMessageImageCommandRepositoryIntegrationTests : BaseChatMessageImageInfrastructureCommandIntegrationTest
{
	public AddRangeChatMessageImageCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
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
