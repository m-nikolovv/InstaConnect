using InstaConnect.Chats.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Extensions;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatApplicationCommandIntegrationTest : BaseChatWebTest
{
	protected IApplicationSender Sender { get; }

	protected IChatEventClient EventClient { get; }

	protected BaseChatApplicationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
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
