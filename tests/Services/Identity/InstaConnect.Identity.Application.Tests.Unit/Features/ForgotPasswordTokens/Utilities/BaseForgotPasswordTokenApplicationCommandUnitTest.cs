using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenApplicationCommandUnitTest : BaseIdentityCommandTest
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
