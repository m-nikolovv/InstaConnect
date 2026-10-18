using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public abstract class BasePostCommentImageTest : BaseTest
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

	protected PostCommentBuilderFactory PostCommentBuilderFactory { get; }
	protected PostCommentBuilder PostCommentBuilder { get; }
	protected PostComment PostComment { get; }
	protected ICollection<PostComment> PostComments { get; }

	protected PostCommentIdBuilderFactory PostCommentIdBuilderFactory { get; }
	protected PostCommentIdBuilder PostCommentIdBuilder { get; }
	protected PostCommentId PostCommentId { get; }

	protected PostCommentIdRangeBuilderFactory PostCommentIdRangeBuilderFactory { get; }
	protected PostCommentIdRangeBuilder PostCommentIdRangeBuilder { get; }
	protected ICollection<PostCommentId> PostCommentIds { get; }

	protected PostCommentImageBuilderFactory PostCommentImageBuilderFactory { get; }
	protected PostCommentImageBuilder PostCommentImageBuilder { get; }
	protected PostCommentImage PostCommentImage { get; }
	protected ICollection<PostCommentImage> PostCommentImages { get; }

	protected PostCommentImageIdBuilderFactory PostCommentImageIdBuilderFactory { get; }
	protected PostCommentImageIdBuilder PostCommentImageIdBuilder { get; }
	protected PostCommentImageId PostCommentImageId { get; }

	protected PostCommentImageIdRangeBuilderFactory PostCommentImageIdRangeBuilderFactory { get; }
	protected PostCommentImageIdRangeBuilder PostCommentImageIdRangeBuilder { get; }
	protected ICollection<PostCommentImageId> PostCommentImageIds { get; }

	protected BasePostCommentImageTest()
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

		PostCommentBuilderFactory = new();
		PostCommentBuilder = PostCommentBuilderFactory.Create(Post, User);
		PostComment = PostCommentBuilder.Build();
		PostComments = PostComment.Generate(Posts, Users);

		PostCommentIdBuilderFactory = new();
		PostCommentIdBuilder = PostCommentIdBuilderFactory.Create(PostComment.Id);
		PostCommentId = PostCommentIdBuilder.Build();

		PostCommentIdRangeBuilderFactory = new();
		PostCommentIdRangeBuilder = PostCommentIdRangeBuilderFactory.Create([.. PostComments.Select(p => p.Id)]);
		PostCommentIds = PostCommentIdRangeBuilder.Build();

		PostCommentImageBuilderFactory = new();
		PostCommentImageBuilder = PostCommentImageBuilderFactory.Create(PostComment);
		PostCommentImage = PostCommentImageBuilder.Build();
		PostCommentImages = PostCommentImage.Generate(PostComments);

		PostCommentImageIdBuilderFactory = new();
		PostCommentImageIdBuilder = PostCommentImageIdBuilderFactory.Create(PostCommentImage.Id);
		PostCommentImageId = PostCommentImageIdBuilder.Build();

		PostCommentImageIdRangeBuilderFactory = new();
		PostCommentImageIdRangeBuilder = PostCommentImageIdRangeBuilderFactory.Create([.. PostCommentImages.Select(p => p.Id)]);
		PostCommentImageIds = PostCommentImageIdRangeBuilder.Build();
	}
}
