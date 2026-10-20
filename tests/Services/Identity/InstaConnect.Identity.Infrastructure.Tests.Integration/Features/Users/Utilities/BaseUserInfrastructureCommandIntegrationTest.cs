using InstaConnect.Identity.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandIntegrationTest : BaseUserWebTest
{
	protected IUserCommandRepository Repository { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetIncludeBuilderFactory();
	}
}
