using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Extensions;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowDomainCommandIntegrationTest : BaseFollowWebTest
{
	protected IFollowCommandService Service { get; }

	protected IFollowEventClient EventClient { get; }

	protected IFollowNotificationClient NotificationClient { get; }

	protected BaseFollowDomainCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetFollowCommandService();
		EventClient = webApplicationFactory.CreateEventClient();
		NotificationClient = webApplicationFactory.CreateNotificationClient(FollowingId);
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(Follower, CancellationToken);
		await ServiceScope.AddAsync(Following, CancellationToken);
		await OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
		await NotificationClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
		await NotificationClient.StopAsync(CancellationToken);
	}
}
