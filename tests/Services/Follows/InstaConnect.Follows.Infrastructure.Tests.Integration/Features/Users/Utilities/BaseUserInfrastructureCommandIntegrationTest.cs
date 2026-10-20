using InstaConnect.Follows.Domain.Features.Users.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandIntegrationTest : BaseUserWebTest
{
	protected IUserCommandRepository Repository { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserInfrastructureCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetUserCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetUserIncludeBuilderFactory();
	}
}
