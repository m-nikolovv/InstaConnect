using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeDomainQueryUnitTest : BasePostCommentLikeTest
{
	protected IPostQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	protected IPostCommentQueryRepository CommentRepository { get; }

	protected IPostCommentLikeQueryRepository CommentLikeRepository { get; }

	internal IPostCommentLikeCollectionResponseFactory CollectionResponseFactory { get; }

	protected BasePostCommentLikeDomainQueryUnitTest()
	{
		Repository = PostDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		CommentRepository = PostCommentDomainMockFactory.CreateQueryRepository();
		CommentLikeRepository = PostCommentLikeDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = PostCommentLikeDomainMockFactory.CreateCollectionResponseFactory();
	}
}
