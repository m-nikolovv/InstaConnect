using InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public abstract class BaseUserTest : BasePostsTest
{
	protected ICollection<Post> UserPosts { get; }
	protected PostIdRangeBuilderFactory UserPostIdRangeBuilderFactory { get; }
	protected PostIdRangeBuilder UserPostIdRangeBuilder { get; }
	protected ICollection<PostId> UserPostIds { get; }

	protected ICollection<PostLike> UserPostLikes { get; }
	protected PostLikeIdRangeBuilderFactory UserPostLikeIdRangeBuilderFactory { get; }
	protected PostLikeIdRangeBuilder UserPostLikeIdRangeBuilder { get; }
	protected ICollection<PostLikeId> UserPostLikeIds { get; }

	protected ICollection<PostComment> UserPostComments { get; }
	protected PostCommentIdRangeBuilderFactory UserPostCommentIdRangeBuilderFactory { get; }
	protected PostCommentIdRangeBuilder UserPostCommentIdRangeBuilder { get; }
	protected ICollection<PostCommentId> UserPostCommentIds { get; }

	protected ICollection<PostCommentLike> UserPostCommentLikes { get; }
	protected PostCommentLikeIdRangeBuilderFactory UserPostCommentLikeIdRangeBuilderFactory { get; }
	protected PostCommentLikeIdRangeBuilder UserPostCommentLikeIdRangeBuilder { get; }
	protected ICollection<PostCommentLikeId> UserPostCommentLikeIds { get; }

	protected ICollection<PostImage> UserPostsPostImages { get; }
	protected PostImageIdRangeBuilderFactory UserPostsPostImageIdRangeBuilderFactory { get; }
	protected PostImageIdRangeBuilder UserPostsPostImageIdRangeBuilder { get; }
	protected ICollection<PostImageId> UserPostsPostImageIds { get; }

	protected ICollection<PostLike> UserPostsPostLikes { get; }
	protected PostLikeIdRangeBuilderFactory UserPostsPostLikeIdRangeBuilderFactory { get; }
	protected PostLikeIdRangeBuilder UserPostsPostLikeIdRangeBuilder { get; }
	protected ICollection<PostLikeId> UserPostsPostLikeIds { get; }

	protected ICollection<PostComment> UserPostsPostComments { get; }
	protected PostCommentIdRangeBuilderFactory UserPostsPostCommentIdRangeBuilderFactory { get; }
	protected PostCommentIdRangeBuilder UserPostsPostCommentIdRangeBuilder { get; }
	protected ICollection<PostCommentId> UserPostsPostCommentIds { get; }

	protected ICollection<PostCommentImage> UserPostsPostCommentsPostCommentImages { get; }
	protected PostCommentImageIdRangeBuilderFactory UserPostsPostCommentsPostCommentImageIdRangeBuilderFactory { get; }
	protected PostCommentImageIdRangeBuilder UserPostsPostCommentsPostCommentImageIdRangeBuilder { get; }
	protected ICollection<PostCommentImageId> UserPostsPostCommentsPostCommentImageIds { get; }

	protected ICollection<PostCommentLike> UserPostsPostCommentsPostCommentLikes { get; }
	protected PostCommentLikeIdRangeBuilderFactory UserPostsPostCommentsPostCommentLikeIdRangeBuilderFactory { get; }
	protected PostCommentLikeIdRangeBuilder UserPostsPostCommentsPostCommentLikeIdRangeBuilder { get; }
	protected ICollection<PostCommentLikeId> UserPostsPostCommentsPostCommentLikeIds { get; }

	protected ICollection<PostCommentImage> UserPostCommentsPostCommentImages { get; }
	protected PostCommentImageIdRangeBuilderFactory UserPostCommentsPostCommentImageIdRangeBuilderFactory { get; }
	protected PostCommentImageIdRangeBuilder UserPostCommentsPostCommentImageIdRangeBuilder { get; }
	protected ICollection<PostCommentImageId> UserPostCommentsPostCommentImageIds { get; }

	protected ICollection<PostCommentLike> UserPostCommentsPostCommentLikes { get; }
	protected PostCommentLikeIdRangeBuilderFactory UserPostCommentsPostCommentLikeIdRangeBuilderFactory { get; }
	protected PostCommentLikeIdRangeBuilder UserPostCommentsPostCommentLikeIdRangeBuilder { get; }
	protected ICollection<PostCommentLikeId> UserPostCommentsPostCommentLikeIds { get; }

	protected BaseUserTest()
	{
		UserPosts = [.. User.Posts];
		UserPostIdRangeBuilderFactory = new();
		UserPostIdRangeBuilder = UserPostIdRangeBuilderFactory.Create([.. UserPosts.Select(p => p.Id)]);
		UserPostIds = UserPostIdRangeBuilder.Build();

		UserPostLikes = [.. User.PostLikes];
		UserPostLikeIdRangeBuilderFactory = new();
		UserPostLikeIdRangeBuilder = UserPostLikeIdRangeBuilderFactory.Create([.. UserPostLikes.Select(p => p.Id)]);
		UserPostLikeIds = UserPostLikeIdRangeBuilder.Build();

		UserPostComments = [.. User.PostComments];
		UserPostCommentIdRangeBuilderFactory = new();
		UserPostCommentIdRangeBuilder = UserPostCommentIdRangeBuilderFactory.Create([.. UserPostComments.Select(p => p.Id)]);
		UserPostCommentIds = UserPostCommentIdRangeBuilder.Build();

		UserPostCommentLikes = [.. User.PostCommentLikes];
		UserPostCommentLikeIdRangeBuilderFactory = new();
		UserPostCommentLikeIdRangeBuilder = UserPostCommentLikeIdRangeBuilderFactory.Create([.. UserPostCommentLikes.Select(p => p.Id)]);
		UserPostCommentLikeIds = UserPostCommentLikeIdRangeBuilder.Build();

		UserPostsPostImages = [.. User.Posts.SelectMany(p => p.PostImages)];
		UserPostsPostImageIdRangeBuilderFactory = new();
		UserPostsPostImageIdRangeBuilder = UserPostsPostImageIdRangeBuilderFactory.Create([.. UserPostsPostImages.Select(p => p.Id)]);
		UserPostsPostImageIds = UserPostsPostImageIdRangeBuilder.Build();

		UserPostsPostLikes = [.. User.Posts.SelectMany(p => p.PostLikes)];
		UserPostsPostLikeIdRangeBuilderFactory = new();
		UserPostsPostLikeIdRangeBuilder = UserPostsPostLikeIdRangeBuilderFactory.Create([.. UserPostsPostLikes.Select(p => p.Id)]);
		UserPostsPostLikeIds = UserPostsPostLikeIdRangeBuilder.Build();

		UserPostsPostComments = [.. User.Posts.SelectMany(p => p.PostComments)];
		UserPostsPostCommentIdRangeBuilderFactory = new();
		UserPostsPostCommentIdRangeBuilder = UserPostsPostCommentIdRangeBuilderFactory.Create([.. UserPostsPostComments.Select(p => p.Id)]);
		UserPostsPostCommentIds = UserPostsPostCommentIdRangeBuilder.Build();

		UserPostsPostCommentsPostCommentImages = [.. User.Posts.SelectMany(p => p.PostComments).SelectMany(p => p.PostCommentImages)];
		UserPostsPostCommentsPostCommentImageIdRangeBuilderFactory = new();
		UserPostsPostCommentsPostCommentImageIdRangeBuilder = UserPostsPostCommentsPostCommentImageIdRangeBuilderFactory.Create([.. UserPostsPostCommentsPostCommentImages.Select(p => p.Id)]);
		UserPostsPostCommentsPostCommentImageIds = UserPostsPostCommentsPostCommentImageIdRangeBuilder.Build();

		UserPostsPostCommentsPostCommentLikes = [.. User.Posts.SelectMany(p => p.PostComments).SelectMany(p => p.PostCommentLikes)];
		UserPostsPostCommentsPostCommentLikeIdRangeBuilderFactory = new();
		UserPostsPostCommentsPostCommentLikeIdRangeBuilder = UserPostsPostCommentsPostCommentLikeIdRangeBuilderFactory.Create([.. UserPostsPostCommentsPostCommentLikes.Select(p => p.Id)]);
		UserPostsPostCommentsPostCommentLikeIds = UserPostsPostCommentsPostCommentLikeIdRangeBuilder.Build();

		UserPostCommentsPostCommentImages = [.. User.PostComments.SelectMany(p => p.PostCommentImages)];
		UserPostCommentsPostCommentImageIdRangeBuilderFactory = new();
		UserPostCommentsPostCommentImageIdRangeBuilder = UserPostCommentsPostCommentImageIdRangeBuilderFactory.Create([.. UserPostCommentsPostCommentImages.Select(p => p.Id)]);
		UserPostCommentsPostCommentImageIds = UserPostCommentsPostCommentImageIdRangeBuilder.Build();

		UserPostCommentsPostCommentLikes = [.. User.PostComments.SelectMany(p => p.PostCommentLikes)];
		UserPostCommentsPostCommentLikeIdRangeBuilderFactory = new();
		UserPostCommentsPostCommentLikeIdRangeBuilder = UserPostCommentsPostCommentLikeIdRangeBuilderFactory.Create([.. UserPostCommentsPostCommentLikes.Select(p => p.Id)]);
		UserPostCommentsPostCommentLikeIds = UserPostCommentsPostCommentLikeIdRangeBuilder.Build();
	}
}
