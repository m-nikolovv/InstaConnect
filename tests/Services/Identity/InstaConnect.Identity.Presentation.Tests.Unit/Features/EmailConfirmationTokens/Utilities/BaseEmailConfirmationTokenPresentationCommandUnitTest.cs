
namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenPresentationCommandUnitTest : BaseIdentityCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseEmailConfirmationTokenPresentationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher(), false)
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);

		PasswordHasher.ClearCalls();
	}
}
