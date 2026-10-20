using InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenPresentationCommandUnitTest : BaseRefreshTokenTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected IRefreshTokenCookieStore CookieStore { get; }

	protected BaseRefreshTokenPresentationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);
		CookieStore = RefreshTokenPresentationMockFactory.CreateCookieStore();

		PasswordHasher.ClearCalls();
	}
}
