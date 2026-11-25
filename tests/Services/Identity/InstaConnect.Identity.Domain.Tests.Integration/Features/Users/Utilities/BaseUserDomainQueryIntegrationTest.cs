using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserDomainQueryIntegrationTest : BaseUserWebQueryTest
{
	protected IUserQueryService Service { get; }

	protected IUserCacheHandler CacheHandler { get; }

	protected BaseUserDomainQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetQueryService();
		CacheHandler = ServiceScope.GetCacheHandler();
	}
}
