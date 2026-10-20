using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageDomainCommandIntegrationTest : BaseChatMessageWebTest
{
	protected IChatMessageCommandService Service { get; }

	protected IChatMessageNotificationClient MessageNotificationClient { get; }

	protected BaseChatMessageDomainCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetChatMessageCommandService();
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
