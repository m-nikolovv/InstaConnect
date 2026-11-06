
namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationCommandUnitTest : BaseIdentityCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserClaimPresentationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);

		PasswordHasher.ClearCalls();
	}
}
