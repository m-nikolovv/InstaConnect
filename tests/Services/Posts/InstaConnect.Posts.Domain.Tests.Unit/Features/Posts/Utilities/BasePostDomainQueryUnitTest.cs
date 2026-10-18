using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostDomainQueryUnitTest : BasePostTest
{
	protected IPostAnalyzer Analyzer { get; }

	protected IPostQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	protected IPostCollectionResponseFactory CollectionResponseFactory { get; }

	protected BasePostDomainQueryUnitTest()
	{
		Analyzer = PostDomainMockFactory.CreateAnalyzer();
		Repository = PostDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = PostDomainMockFactory.CreateCollectionResponseFactory();
	}
}
