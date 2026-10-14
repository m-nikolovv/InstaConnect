using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public abstract class BasePostLikeTest : BaseTest
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

	protected BasePostLikeTest()
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
	}
}
