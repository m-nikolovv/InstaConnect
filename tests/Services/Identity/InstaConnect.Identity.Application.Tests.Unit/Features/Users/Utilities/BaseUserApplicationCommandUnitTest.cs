using InstaConnect.Identity.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseIdentityCommandTest
{
	protected IApplicationMapper Mapper { get; }

	protected IUserCommandService Service { get; }

	protected BaseUserApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
		Service = UserApplicationMockFactory.CreateCommandService();

		PasswordHasher.ClearCalls();
	}
}
