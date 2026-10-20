using InstaConnect.Posts.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public abstract class BasePostTest : BaseTest
{
	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }
	protected ICollection<User> Users { get; }

	protected UserIdBuilderFactory UserIdBuilderFactory { get; }
	protected UserIdBuilder UserIdBuilder { get; }
	protected UserId UserId { get; }

	protected UserIdRangeBuilderFactory UserIdRangeBuilderFactory { get; }
	protected UserIdRangeBuilder UserIdRangeBuilder { get; }
	protected ICollection<UserId> UserIds { get; }

	protected PostBuilderFactory PostBuilderFactory { get; }
	protected PostBuilder PostBuilder { get; }
	protected Post Post { get; }
	protected ICollection<Post> Posts { get; }

	protected PostIdBuilderFactory PostIdBuilderFactory { get; }
	protected PostIdBuilder PostIdBuilder { get; }
	protected PostId PostId { get; }

	protected PostIdRangeBuilderFactory PostIdRangeBuilderFactory { get; }
	protected PostIdRangeBuilder PostIdRangeBuilder { get; }
	protected ICollection<PostId> PostIds { get; }

	protected PostLikeBuilderFactory PostLikeBuilderFactory { get; }
	protected PostLikeBuilder PostLikeBuilder { get; }
	protected PostLike PostLike { get; }
	protected ICollection<PostLike> PostLikes { get; }

	protected PostLikeIdBuilderFactory PostLikeIdBuilderFactory { get; }
	protected PostLikeIdBuilder PostLikeIdBuilder { get; }
	protected PostLikeId PostLikeId { get; }

	protected PostLikeIdRangeBuilderFactory PostLikeIdRangeBuilderFactory { get; }
	protected PostLikeIdRangeBuilder PostLikeIdRangeBuilder { get; }
	protected ICollection<PostLikeId> PostLikeIds { get; }

	protected PostImageBuilderFactory PostImageBuilderFactory { get; }
	protected PostImageBuilder PostImageBuilder { get; }
	protected PostImage PostImage { get; }
	protected ICollection<PostImage> PostImages { get; }

	protected PostImageIdBuilderFactory PostImageIdBuilderFactory { get; }
	protected PostImageIdBuilder PostImageIdBuilder { get; }
	protected PostImageId PostImageId { get; }

	protected PostImageIdRangeBuilderFactory PostImageIdRangeBuilderFactory { get; }
	protected PostImageIdRangeBuilder PostImageIdRangeBuilder { get; }
	protected ICollection<PostImageId> PostImageIds { get; }

	protected BasePostTest()
	{
		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create();
		User = UserBuilder.Build();
		Users = User.Generate();

		UserIdBuilderFactory = new();
		UserIdBuilder = UserIdBuilderFactory.Create(User.Id);
		UserId = UserIdBuilder.Build();

		UserIdRangeBuilderFactory = new();
		UserIdRangeBuilder = UserIdRangeBuilderFactory.Create([.. Users.Select(p => p.Id)]);
		UserIds = UserIdRangeBuilder.Build();

		PostBuilderFactory = new();
		PostBuilder = PostBuilderFactory.Create(User);
		Post = PostBuilder.Build();
		Posts = Post.Generate(Users);

		PostIdBuilderFactory = new();
		PostIdBuilder = PostIdBuilderFactory.Create(Post.Id);
		PostId = PostIdBuilder.Build();

		PostIdRangeBuilderFactory = new();
		PostIdRangeBuilder = PostIdRangeBuilderFactory.Create([.. Posts.Select(p => p.Id)]);
		PostIds = PostIdRangeBuilder.Build();

		PostLikeBuilderFactory = new();
		PostLikeBuilder = PostLikeBuilderFactory.Create(Post, User);
		PostLike = PostLikeBuilder.Build();
		PostLikes = PostLike.Generate(Posts, Users);

		PostLikeIdBuilderFactory = new();
		PostLikeIdBuilder = PostLikeIdBuilderFactory.Create(PostLike.Id);
		PostLikeId = PostLikeIdBuilder.Build();

		PostLikeIdRangeBuilderFactory = new();
		PostLikeIdRangeBuilder = PostLikeIdRangeBuilderFactory.Create([.. PostLikes.Select(p => p.Id)]);
		PostLikeIds = PostLikeIdRangeBuilder.Build();

		PostImageBuilderFactory = new();
		PostImageBuilder = PostImageBuilderFactory.Create(Post);
		PostImage = PostImageBuilder.Build();
		PostImages = PostImage.Generate(Posts);

		PostImageIdBuilderFactory = new();
		PostImageIdBuilder = PostImageIdBuilderFactory.Create(PostImage.Id);
		PostImageId = PostImageIdBuilder.Build();

		PostImageIdRangeBuilderFactory = new();
		PostImageIdRangeBuilder = PostImageIdRangeBuilderFactory.Create([.. PostImages.Select(p => p.Id)]);
		PostImageIds = PostImageIdRangeBuilder.Build();
	}
}
