
namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryUnitTest : BaseIdentityQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserClaimPresentationQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);

		PasswordHasher.ClearCalls();
	}
}
