using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationCommandIntegrationTest : BaseChatMessageWebTest
{
	protected IApplicationSender Sender { get; }

	protected IChatMessageNotificationClient MessageNotificationClient { get; }

	protected BaseChatMessageApplicationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		MessageNotificationClient = webApplicationFactory.CreateMessageNotificationClient(ParticipantTwoId);
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddAsync(Chat, CancellationToken);
		await OnInitializeAsync();
		await MessageNotificationClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await MessageNotificationClient.StopAsync(CancellationToken);
	}
}
