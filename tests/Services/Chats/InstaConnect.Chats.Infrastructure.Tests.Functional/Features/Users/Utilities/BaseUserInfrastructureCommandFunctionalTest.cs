using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Extensions;
using InstaConnect.Chats.Tests.Features.Common.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandFunctionalTest : BaseUserWebTest
{
	protected IUserEventClient UserEventClient { get; }

	protected IEventPublisher EventPublisher { get; }

	protected BaseUserInfrastructureCommandFunctionalTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
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
