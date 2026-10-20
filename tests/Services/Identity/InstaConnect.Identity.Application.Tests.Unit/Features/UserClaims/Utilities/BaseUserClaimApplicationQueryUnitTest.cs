using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationQueryUnitTest : BaseUserClaimTest
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
