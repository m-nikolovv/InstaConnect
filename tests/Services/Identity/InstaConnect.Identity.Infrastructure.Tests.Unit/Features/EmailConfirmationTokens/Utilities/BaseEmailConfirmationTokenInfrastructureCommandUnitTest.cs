using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenInfrastructureCommandUnitTest : BaseEmailConfirmationTokenCommandTest
{
	protected IEmailConfirmationTokenFluent Fluent { get; }

	protected IEmailConfirmationTokenCollection Collection { get; }

	protected IEmailConfirmationTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseEmailConfirmationTokenInfrastructureCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher(), false)
	{
		Fluent = EmailConfirmationTokenInfrastructureMockFactory.CreateFluent();
		Collection = EmailConfirmationTokenInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = EmailConfirmationTokenMockFactory.CreateIncludeBuilderFactory();

		PasswordHasher.ClearCalls();
	}
}
