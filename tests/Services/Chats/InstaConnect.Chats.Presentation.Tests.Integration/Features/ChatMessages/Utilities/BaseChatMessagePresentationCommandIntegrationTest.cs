using InstaConnect.Chats.Presentation.Features.ChatMessages.Controllers.v1;
using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandIntegrationTest : BaseChatMessageWebCommandTest
{
	protected ChatMessageController Controller { get; }

	protected IChatMessageNotificationClient MessageNotificationClient { get; }

	protected BaseChatMessagePresentationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatMessageController();
		MessageNotificationClient = webApplicationFactory.CreateMessageNotificationClient(ParticipantTwoId);
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await MessageNotificationClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await MessageNotificationClient.StopAsync(CancellationToken);
	}
}
