using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserDomainQueryIntegrationTest : BaseUserWebTest
{
	protected IUserQueryService Service { get; }

	protected BaseUserDomainQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetQueryService();
	}
}
