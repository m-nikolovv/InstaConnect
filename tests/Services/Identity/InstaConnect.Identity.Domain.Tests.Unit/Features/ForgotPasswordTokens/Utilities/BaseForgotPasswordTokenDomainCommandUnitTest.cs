using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenDomainCommandUnitTest : BaseForgotPasswordTokenTest
{
	protected IApplicationMapper Mapper { get; }

	protected IGuidProvider GuidProvider { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IUserCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IForgotPasswordTokenFactory Factory { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IForgotPasswordTokenEmailSender EmailSender { get; }

	protected IOptions<ForgotPasswordTokenOptions> ForgotPasswordTokenOptions { get; }

	protected IForgotPasswordTokenCommandRepository ForgotPasswordTokenRepository { get; }

	protected BaseForgotPasswordTokenDomainCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Mapper = MockFactory.CreateMapper(IdentityDomainReference.Assembly);
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = UserDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		Factory = ForgotPasswordTokenDomainMockFactory.CreateFactory();
		IncludeBuilderFactory = UserDomainMockFactory.CreateIncludeBuilderFactory();
		EmailSender = ForgotPasswordTokenDomainMockFactory.CreateEmailSender();
		ForgotPasswordTokenOptions = ForgotPasswordTokenDomainMockFactory.CreateOptions();
		ForgotPasswordTokenRepository = ForgotPasswordTokenDomainMockFactory.CreateCommandRepository();

		PasswordHasher.ClearCalls();
	}
}
