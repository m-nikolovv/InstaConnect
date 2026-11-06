using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationQueryUnitTest : BasePostsQueryTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostCommentQueryService CommentService { get; }

	protected BasePostCommentApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		CommentService = PostCommentApplicationMockFactory.CreateQueryService();
	}
}
