using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimDomainQueryUnitTest : BaseUserClaimQueryTest
{
	protected IUserQueryRepository Repository { get; }

	protected IUserClaimQueryRepository ClaimRepository { get; }

	protected IUserClaimCollectionResponseFactory CollectionResponseFactory { get; }

	protected BaseUserClaimDomainQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Repository = UserDomainMockFactory.CreateQueryRepository();
		ClaimRepository = UserClaimDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = UserClaimDomainMockFactory.CreateCollectionResponseFactory();

		PasswordHasher.ClearCalls();
	}
}
