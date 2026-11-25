using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public abstract class BaseUserWebQueryTest : BaseUserWebTest
{
	protected BaseUserWebQueryTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Followers, CancellationToken);
		await ServiceScope.AddRangeAsync(Followings, CancellationToken);
		await OnInitializeAsync();
	}
}
