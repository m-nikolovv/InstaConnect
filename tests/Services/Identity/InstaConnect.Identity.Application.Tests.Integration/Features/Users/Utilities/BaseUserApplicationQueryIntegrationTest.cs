using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserApplicationQueryIntegrationTest : BaseUserWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IUserCacheHandler CacheHandler { get; }

	protected BaseUserApplicationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		CacheHandler = ServiceScope.GetCacheHandler();
	}
}
