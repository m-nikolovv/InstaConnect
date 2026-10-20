namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public abstract class BasePostImageTest : BaseTest
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

	protected BasePostImageTest()
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
