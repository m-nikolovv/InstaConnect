using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public abstract class BaseFollowWebQueryTest : BaseFollowWebTest
{
	protected BaseFollowWebQueryTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Followers, CancellationToken);
		await ServiceScope.AddRangeAsync(Followings, CancellationToken);
		await ServiceScope.AddRangeAsync(Follows, CancellationToken);
		await OnInitializeAsync();
	}
}
