using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Extensions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerIntegrationTest : BaseChatsWebCommandTest
{
	protected IUserEventClient UserEventClient { get; }

	protected IEventPublisher EventPublisher { get; }

	protected BaseUserInfrastructureEventHandlerIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		UserEventClient = webApplicationFactory.CreateUserEventClient();
		EventPublisher = ServiceScope.GetEventPublisher();
	}

	public override async Task InitializeAsync()
	{
		await OnInitializeAsync();
		await UserEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await UserEventClient.StopAsync(CancellationToken);
	}
}
