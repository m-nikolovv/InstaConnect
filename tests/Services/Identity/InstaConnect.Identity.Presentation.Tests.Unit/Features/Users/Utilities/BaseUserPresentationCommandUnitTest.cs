using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandUnitTest : BaseUserTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserPresentationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);

		PasswordHasher.ClearCalls();
	}
}
