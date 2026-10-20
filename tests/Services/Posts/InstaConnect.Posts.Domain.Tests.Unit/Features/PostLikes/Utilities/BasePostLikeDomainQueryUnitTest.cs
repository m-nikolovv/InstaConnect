using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;

public abstract class BasePostLikeDomainQueryUnitTest : BasePostLikeTest
{
	protected IPostQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	protected IPostLikeQueryRepository LikeRepository { get; }

	internal IPostLikeCollectionResponseFactory CollectionResponseFactory { get; }

	protected BasePostLikeDomainQueryUnitTest()
	{
		Repository = PostDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		LikeRepository = PostLikeDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = PostLikeDomainMockFactory.CreateCollectionResponseFactory();
	}
}
