using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenInfrastructureCommandUnitTest : BaseForgotPasswordTokenCommandTest
{
	protected IForgotPasswordTokenFluent Fluent { get; }

	protected IForgotPasswordTokenCollection Collection { get; }

	protected IForgotPasswordTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseForgotPasswordTokenInfrastructureCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Fluent = ForgotPasswordTokenInfrastructureMockFactory.CreateFluent();
		Collection = ForgotPasswordTokenInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = ForgotPasswordTokenMockFactory.CreateIncludeBuilderFactory();

		PasswordHasher.ClearCalls();
	}
}
