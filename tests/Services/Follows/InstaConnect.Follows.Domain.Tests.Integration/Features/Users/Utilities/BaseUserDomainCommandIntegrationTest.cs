using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserDomainCommandIntegrationTest : BaseUserWebTest
{
	protected IUserCommandService UserService { get; }

	protected BaseUserDomainCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		UserService = ServiceScope.GetUserCommandService();
	}
}
