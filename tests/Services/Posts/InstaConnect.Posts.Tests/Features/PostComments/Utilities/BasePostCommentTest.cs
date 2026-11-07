using InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public abstract class BasePostCommentTest : BasePostsTest
{
	protected ICollection<PostCommentImage> PostCommentPostCommentImages { get; }
	protected PostCommentImageIdRangeBuilderFactory PostCommentPostCommentImageIdRangeBuilderFactory { get; }
	protected PostCommentImageIdRangeBuilder PostCommentPostCommentImageIdRangeBuilder { get; }
	protected ICollection<PostCommentImageId> PostCommentPostCommentImageIds { get; }

	protected ICollection<PostCommentLike> PostCommentPostCommentLikes { get; }
	protected PostCommentLikeIdRangeBuilderFactory PostCommentPostCommentLikeIdRangeBuilderFactory { get; }
	protected PostCommentLikeIdRangeBuilder PostCommentPostCommentLikeIdRangeBuilder { get; }
	protected ICollection<PostCommentLikeId> PostCommentPostCommentLikeIds { get; }

	protected BasePostCommentTest()
	{
		PostCommentPostCommentImages = [.. PostComment.PostCommentImages];
		PostCommentPostCommentImageIdRangeBuilderFactory = new();
		PostCommentPostCommentImageIdRangeBuilder = PostCommentPostCommentImageIdRangeBuilderFactory.Create([.. PostCommentPostCommentImages.Select(p => p.Id)]);
		PostCommentPostCommentImageIds = PostCommentPostCommentImageIdRangeBuilder.Build();

		PostCommentPostCommentLikes = [.. PostComment.PostCommentLikes];
		PostCommentPostCommentLikeIdRangeBuilderFactory = new();
		PostCommentPostCommentLikeIdRangeBuilder = PostCommentPostCommentLikeIdRangeBuilderFactory.Create([.. PostCommentPostCommentLikes.Select(p => p.Id)]);
		PostCommentPostCommentLikeIds = PostCommentPostCommentLikeIdRangeBuilder.Build();
	}
}
