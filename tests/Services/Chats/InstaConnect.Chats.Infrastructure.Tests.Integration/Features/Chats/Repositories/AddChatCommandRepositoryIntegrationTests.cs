using InstaConnect.Chats.Tests.Features.Chats.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Repositories;

public class AddChatCommandRepositoryIntegrationTests : BaseChatInfrastructureCommandIntegrationTest
{
	public AddChatCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task AddAsync_ShouldAddChat_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(Chat, CancellationToken);
		var chat = await ServiceScope.GetByIdAsync(ChatId, CancellationToken);

		// Assert
		chat.ShouldSatisfy(Chat);
	}
}
