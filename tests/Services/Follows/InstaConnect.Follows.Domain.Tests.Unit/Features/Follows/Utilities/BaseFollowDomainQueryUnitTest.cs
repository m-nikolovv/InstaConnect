using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowDomainQueryUnitTest : BaseFollowsQueryTest
{
	protected IFollowQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	internal IFollowCollectionResponseFactory CollectionResponseFactory { get; }

	protected BaseFollowDomainQueryUnitTest()
	{
		Repository = FollowDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = FollowDomainMockFactory.CreateCollectionResponseFactory();
	}
}
