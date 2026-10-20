using InstaConnect.Chats.Presentation.Features.Chats.Controllers.v1;
using InstaConnect.Chats.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Extensions;

namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatPresentationCommandIntegrationTest : BaseChatWebTest
{
	protected ChatController Controller { get; }

	protected IChatEventClient EventClient { get; }

	protected BaseChatPresentationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatController();
		EventClient = webApplicationFactory.CreateEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddAsync(ParticipantTwo, CancellationToken);
		await OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
	}
}
