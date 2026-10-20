using InstaConnect.Identity.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryIntegrationTest : BaseUserWebTest
{
	protected IUserQueryRepository Repository { get; }

	protected BaseUserInfrastructureQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetQueryRepository();
	}
}
