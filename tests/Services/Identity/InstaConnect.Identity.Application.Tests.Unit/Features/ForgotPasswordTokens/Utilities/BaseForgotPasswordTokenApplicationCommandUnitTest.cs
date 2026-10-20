using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenApplicationCommandUnitTest : BaseForgotPasswordTokenTest
{
	protected IApplicationMapper Mapper { get; }

	protected IForgotPasswordTokenCommandService Service { get; }

	protected BaseForgotPasswordTokenApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
		Service = ForgotPasswordTokenApplicationMockFactory.CreateCommandService();

		PasswordHasher.ClearCalls();
	}
}
