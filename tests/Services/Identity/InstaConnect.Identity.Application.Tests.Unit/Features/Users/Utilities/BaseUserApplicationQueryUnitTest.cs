using InstaConnect.Identity.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationQueryUnitTest : BaseUserQueryTest
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
