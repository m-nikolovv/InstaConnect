using InstaConnect.Chats.Presentation.Features.ChatMessages.Controllers.v1;

namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationQueryIntegrationTest : BaseChatMessageWebTest
{
	protected ChatMessageController Controller { get; }

	protected BaseChatMessagePresentationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatMessageController();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(ParticipantOnes, CancellationToken);
		await ServiceScope.AddRangeAsync(ParticipantTwos, CancellationToken);
		await ServiceScope.AddRangeAsync(Chats, CancellationToken);
		await OnInitializeAsync();
	}
}
