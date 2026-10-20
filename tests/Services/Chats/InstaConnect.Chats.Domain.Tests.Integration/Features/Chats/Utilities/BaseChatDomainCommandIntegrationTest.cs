using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Extensions;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatDomainCommandIntegrationTest : BaseChatWebTest
{
	protected IChatCommandService Service { get; }

	protected IChatEventClient EventClient { get; }

	protected BaseChatDomainCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetChatCommandService();
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
