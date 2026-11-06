using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationCommandUnitTest : BaseIdentityCommandTest
{
	protected IApplicationMapper Mapper { get; }

	protected IUserClaimCommandService Service { get; }

	protected BaseUserClaimApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
		Service = UserClaimApplicationMockFactory.CreateCommandService();

		PasswordHasher.ClearCalls();
	}
}
