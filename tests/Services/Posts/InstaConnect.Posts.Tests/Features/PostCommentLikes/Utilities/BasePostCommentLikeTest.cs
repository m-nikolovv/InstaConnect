using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Builders;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeTest : BaseTest
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

	protected PostCommentLikeBuilderFactory PostCommentLikeBuilderFactory { get; }
	protected PostCommentLikeBuilder PostCommentLikeBuilder { get; }
	protected PostCommentLike PostCommentLike { get; }
	protected ICollection<PostCommentLike> PostCommentLikes { get; }

	protected PostCommentLikeIdBuilderFactory PostCommentLikeIdBuilderFactory { get; }
	protected PostCommentLikeIdBuilder PostCommentLikeIdBuilder { get; }
	protected PostCommentLikeId PostCommentLikeId { get; }

	protected PostCommentLikeIdRangeBuilderFactory PostCommentLikeIdRangeBuilderFactory { get; }
	protected PostCommentLikeIdRangeBuilder PostCommentLikeIdRangeBuilder { get; }
	protected ICollection<PostCommentLikeId> PostCommentLikeIds { get; }

	protected BasePostCommentLikeTest()
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

		PostCommentLikeBuilderFactory = new();
		PostCommentLikeBuilder = PostCommentLikeBuilderFactory.Create(PostComment, User);
		PostCommentLike = PostCommentLikeBuilder.Build();
		PostCommentLikes = PostCommentLike.Generate(PostComments, Users);

		PostCommentLikeIdBuilderFactory = new();
		PostCommentLikeIdBuilder = PostCommentLikeIdBuilderFactory.Create(PostCommentLike.Id);
		PostCommentLikeId = PostCommentLikeIdBuilder.Build();

		PostCommentLikeIdRangeBuilderFactory = new();
		PostCommentLikeIdRangeBuilder = PostCommentLikeIdRangeBuilderFactory.Create([.. PostCommentLikes.Select(p => p.Id)]);
		PostCommentLikeIds = PostCommentLikeIdRangeBuilder.Build();
	}
}
