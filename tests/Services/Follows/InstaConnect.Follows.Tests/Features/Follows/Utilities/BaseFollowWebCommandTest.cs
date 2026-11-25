using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public abstract class BaseFollowWebCommandTest : BaseFollowWebTest
{
	protected BaseFollowWebCommandTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(Follower, CancellationToken);
		await ServiceScope.AddAsync(Following, CancellationToken);
		await OnInitializeAsync();
	}
}
