using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationCommandUnitTest : BasePostCommentTest
{
	protected IApplicationMapper Mapper { get; }

	protected IPostCommentCommandService CommentService { get; }

	protected BasePostCommentApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(PostsApplicationReference.Assembly);
		CommentService = PostCommentApplicationMockFactory.CreateCommandService();
	}
}
