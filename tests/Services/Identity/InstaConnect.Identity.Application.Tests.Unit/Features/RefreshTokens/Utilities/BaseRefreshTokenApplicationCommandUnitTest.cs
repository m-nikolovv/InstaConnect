using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenApplicationCommandUnitTest : BaseRefreshTokenTest
{
	protected IApplicationMapper Mapper { get; }

	protected IRefreshTokenCommandService Service { get; }

	protected BaseRefreshTokenApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
		Service = RefreshTokenApplicationMockFactory.CreateCommandService();

		PasswordHasher.ClearCalls();
	}
}
