using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationQueryUnitTest : BaseUserTest
{
	protected IApplicationMapper Mapper { get; }

	protected IUserQueryService Service { get; }

	protected BaseUserApplicationQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
		Service = UserApplicationMockFactory.CreateQueryService();

		PasswordHasher.ClearCalls();
	}
}
