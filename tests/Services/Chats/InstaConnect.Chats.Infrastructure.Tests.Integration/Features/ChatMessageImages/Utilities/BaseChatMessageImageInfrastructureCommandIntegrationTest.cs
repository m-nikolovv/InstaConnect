using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageInfrastructureCommandIntegrationTest : BaseChatMessageImageWebTest
{
	protected IChatMessageImageCommandRepository Repository { get; }

	protected BaseChatMessageImageInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetMessageImageCommandRepository();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await ServiceScope.AddAsync(ChatMessage, CancellationToken);
		await OnInitializeAsync();
	}
}
