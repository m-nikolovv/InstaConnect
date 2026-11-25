using InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryUnitTest : BaseUserQueryTest
{
	protected IUserFluent Fluent { get; }

	protected IUserCollection Collection { get; }

	protected IUserCacheHandler CacheHandler { get; }

	protected IUserResponseFluent ResponseFluent { get; }

	protected BaseUserInfrastructureQueryUnitTest()
	{
		Fluent = UserInfrastructureMockFactory.CreateFluent();
		Collection = UserInfrastructureMockFactory.CreateCollection();
		CacheHandler = UserInfrastructureMockFactory.CreateCacheHandler();
		ResponseFluent = UserInfrastructureMockFactory.CreateResponseFluent();
	}
}
