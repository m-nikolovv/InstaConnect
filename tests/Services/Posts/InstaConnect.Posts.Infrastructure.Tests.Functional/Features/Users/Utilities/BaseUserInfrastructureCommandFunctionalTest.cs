using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Extensions;
using InstaConnect.Posts.Tests.Features.Common.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandFunctionalTest : BaseUserWebTest
{
	protected IUserEventClient UserEventClient { get; }

	protected IEventPublisher EventPublisher { get; }

	protected BaseUserInfrastructureCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
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
