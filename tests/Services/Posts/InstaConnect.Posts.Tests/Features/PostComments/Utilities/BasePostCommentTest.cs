using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public abstract class BasePostCommentTest : BaseTest
{
	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }
	protected ICollection<User> Users { get; }

	protected PostBuilderFactory PostBuilderFactory { get; }
	protected PostBuilder PostBuilder { get; }
	protected Post Post { get; }
	protected ICollection<Post> Posts { get; }

	protected PostLikeBuilderFactory PostLikeBuilderFactory { get; }
	protected PostLikeBuilder PostLikeBuilder { get; }
	protected PostLike PostLike { get; }
	protected ICollection<PostLike> PostLikes { get; }

	protected PostCommentBuilderFactory PostCommentBuilderFactory { get; }
	protected PostCommentBuilder PostCommentBuilder { get; }
	protected PostComment PostComment { get; }
	protected ICollection<PostComment> PostComments { get; }

	protected PostCommentLikeBuilderFactory PostCommentLikeBuilderFactory { get; }
	protected PostCommentLikeBuilder PostCommentLikeBuilder { get; }
	protected PostCommentLike PostCommentLike { get; }
	protected ICollection<PostCommentLike> PostCommentLikes { get; }

	protected BasePostCommentTest()
	{
		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create();
		User = UserBuilder.Build();
		Users = User.Generate();

		PostBuilderFactory = new();
		PostBuilder = PostBuilderFactory.Create(User);
		Post = PostBuilder.Build();
		Posts = Post.Generate(Users);

		PostLikeBuilderFactory = new();
		PostLikeBuilder = PostLikeBuilderFactory.Create(Post, User);
		PostLike = PostLikeBuilder.Build();
		PostLikes = PostLike.Generate(Posts, Users);

		PostCommentBuilderFactory = new();
		PostCommentBuilder = PostCommentBuilderFactory.Create(Post, User);
		PostComment = PostCommentBuilder.Build();
		PostComments = PostComment.Generate(Posts, Users);

		PostCommentLikeBuilderFactory = new();
		PostCommentLikeBuilder = PostCommentLikeBuilderFactory.Create(PostComment, User);
		PostCommentLike = PostCommentLikeBuilder.Build();
		PostCommentLikes = PostCommentLike.Generate(PostComments, Users);
	}
}
