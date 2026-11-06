using InstaConnect.Posts.Tests.Features.Common.Utilities;
namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostDomainQueryUnitTest : BasePostsQueryTest
{
	protected IPostQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	protected IPostCollectionResponseFactory CollectionResponseFactory { get; }

	protected BasePostDomainQueryUnitTest()
	{
		Repository = PostDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = PostDomainMockFactory.CreateCollectionResponseFactory();
	}
}
