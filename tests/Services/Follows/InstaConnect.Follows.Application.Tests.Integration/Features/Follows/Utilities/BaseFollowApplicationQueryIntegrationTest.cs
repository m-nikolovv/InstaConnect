using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowApplicationQueryIntegrationTest : BaseFollowWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseFollowApplicationQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Followers, CancellationToken);
		await ServiceScope.AddRangeAsync(Followings, CancellationToken);
		await OnInitializeAsync();
	}
}
