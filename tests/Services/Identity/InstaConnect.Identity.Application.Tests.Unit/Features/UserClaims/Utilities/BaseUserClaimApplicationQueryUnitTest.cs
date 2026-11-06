using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationQueryUnitTest : BaseIdentityQueryTest
{
	protected IApplicationMapper Mapper { get; }

	protected IUserClaimQueryService Service { get; }

	protected BaseUserClaimApplicationQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
		Service = UserClaimApplicationMockFactory.CreateQueryService();

		PasswordHasher.ClearCalls();
	}
}
