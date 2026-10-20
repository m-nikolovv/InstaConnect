using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserDomainQueryUnitTest : BaseUserTest
{
	protected IUserQueryRepository Repository { get; }

	protected IUserCollectionResponseFactory CollectionResponseFactory { get; }

	protected BaseUserDomainQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Repository = UserDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = UserDomainMockFactory.CreateCollectionResponseFactory();

		PasswordHasher.ClearCalls();
	}
}
