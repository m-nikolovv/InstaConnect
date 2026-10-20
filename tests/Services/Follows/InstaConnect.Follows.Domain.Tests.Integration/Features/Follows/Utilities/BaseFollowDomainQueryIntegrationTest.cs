using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowDomainQueryIntegrationTest : BaseFollowWebTest
{
	protected IFollowQueryService Service { get; }

	protected BaseFollowDomainQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetFollowQueryService();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Followers, CancellationToken);
		await ServiceScope.AddRangeAsync(Followings, CancellationToken);
		await OnInitializeAsync();
	}
}
