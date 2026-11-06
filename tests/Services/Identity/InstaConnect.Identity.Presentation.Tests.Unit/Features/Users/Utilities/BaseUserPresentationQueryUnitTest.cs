
namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserPresentationQueryUnitTest : BaseIdentityQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserPresentationQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);

		PasswordHasher.ClearCalls();
	}
}
