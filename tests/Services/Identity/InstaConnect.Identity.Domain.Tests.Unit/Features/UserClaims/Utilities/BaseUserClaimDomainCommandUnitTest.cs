using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimDomainCommandUnitTest : BaseUserClaimTest
{
	protected IUserClaimFactory Factory { get; }

	protected IApplicationMapper Mapper { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IUserCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserClaimCommandRepository ClaimRepository { get; }

	protected IUserClaimIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserClaimDomainCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Factory = UserClaimDomainMockFactory.CreateFactory();
		Mapper = MockFactory.CreateMapper(IdentityDomainReference.Assembly);
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = UserDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		ClaimRepository = UserClaimDomainMockFactory.CreateCommandRepository();
		IncludeBuilderFactory = UserClaimDomainMockFactory.CreateIncludeBuilderFactory();

		PasswordHasher.ClearCalls();
	}
}
