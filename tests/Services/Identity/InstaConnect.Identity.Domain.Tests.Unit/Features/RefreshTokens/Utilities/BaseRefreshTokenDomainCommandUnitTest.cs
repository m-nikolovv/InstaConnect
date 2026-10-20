using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenDomainCommandUnitTest : BaseRefreshTokenTest
{
	protected IGuidProvider GuidProvider { get; }

	protected IRefreshTokenFactory Factory { get; }

	protected IUserCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected ISessionTokenGenerator SessionTokenGenerator { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IOptions<RefreshTokenOptions> RefreshTokenOptions { get; }

	protected IRefreshTokenCommandRepository RefreshTokenRepository { get; }

	protected BaseRefreshTokenDomainCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		Factory = RefreshTokenDomainMockFactory.CreateFactory();
		Repository = UserDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		SessionTokenGenerator = RefreshTokenDomainMockFactory.CreateSessionTokenGenerator();
		IncludeBuilderFactory = UserDomainMockFactory.CreateIncludeBuilderFactory();
		RefreshTokenOptions = RefreshTokenDomainMockFactory.CreateOptions();
		RefreshTokenRepository = RefreshTokenDomainMockFactory.CreateCommandRepository();

		PasswordHasher.ClearCalls();
	}
}
