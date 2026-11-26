using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Functional.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandFunctionalTest : BaseChatMessageWebCommandTest
{
	protected IChatMessageApiClient ApiClient { get; }

	protected IChatMessageNotificationClient MessageNotificationClient { get; }

	protected BaseChatMessagePresentationCommandFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		ApiClient = webApplicationFactory.CreateMessageApiClient();
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
