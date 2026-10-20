using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseUserTest
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
