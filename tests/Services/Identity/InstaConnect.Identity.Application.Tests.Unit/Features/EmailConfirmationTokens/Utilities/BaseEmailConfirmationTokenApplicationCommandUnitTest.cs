using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenApplicationCommandUnitTest : BaseIdentityCommandTest
{
	protected IApplicationMapper Mapper { get; }

	protected IEmailConfirmationTokenCommandService Service { get; }

	protected BaseEmailConfirmationTokenApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher(), false)
	{
		Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
		Service = EmailConfirmationTokenApplicationMockFactory.CreateCommandService();

		PasswordHasher.ClearCalls();
	}
}
