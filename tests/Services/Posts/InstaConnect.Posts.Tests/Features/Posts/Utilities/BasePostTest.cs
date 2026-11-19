using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public abstract class BasePostTest : BasePostsTest
{
	protected ICollection<PostImage> PostPostImages { get; }
	protected PostImageIdRangeBuilderFactory PostPostImageIdRangeBuilderFactory { get; }
	protected PostImageIdRangeBuilder PostPostImageIdRangeBuilder { get; }
	protected ICollection<PostImageId> PostPostImageIds { get; }
	protected ICollection<PostImageResponse> PostPostImageResponses { get; }

	protected ICollection<PostLike> PostPostLikes { get; }
	protected PostLikeIdRangeBuilderFactory PostPostLikeIdRangeBuilderFactory { get; }
	protected PostLikeIdRangeBuilder PostPostLikeIdRangeBuilder { get; }
	protected ICollection<PostLikeId> PostPostLikeIds { get; }
	protected ICollection<PostLikeResponse> PostPostLikeResponses { get; }

	protected ICollection<PostComment> PostPostComments { get; }
	protected PostCommentIdRangeBuilderFactory PostPostCommentIdRangeBuilderFactory { get; }
	protected PostCommentIdRangeBuilder PostPostCommentIdRangeBuilder { get; }
	protected ICollection<PostCommentId> PostPostCommentIds { get; }
	protected ICollection<PostCommentResponse> PostPostCommentResponses { get; }

	protected ICollection<PostCommentImage> PostPostCommentsPostCommentImages { get; }
	protected PostCommentImageIdRangeBuilderFactory PostPostCommentsPostCommentImageIdRangeBuilderFactory { get; }
	protected PostCommentImageIdRangeBuilder PostPostCommentsPostCommentImageIdRangeBuilder { get; }
	protected ICollection<PostCommentImageId> PostPostCommentsPostCommentImageIds { get; }
	protected ICollection<PostCommentImageResponse> PostPostCommentsPostCommentImageResponses { get; }

	protected ICollection<PostCommentLike> PostPostCommentsPostCommentLikes { get; }
	protected PostCommentLikeIdRangeBuilderFactory PostPostCommentsPostCommentLikeIdRangeBuilderFactory { get; }
	protected PostCommentLikeIdRangeBuilder PostPostCommentsPostCommentLikeIdRangeBuilder { get; }
	protected ICollection<PostCommentLikeId> PostPostCommentsPostCommentLikeIds { get; }
	protected ICollection<PostCommentLikeResponse> PostPostCommentsPostCommentLikeResponses { get; }

	protected BasePostTest()
	{
		PostPostImages = [.. Post.PostImages];
		PostPostImageIdRangeBuilderFactory = new();
		PostPostImageIdRangeBuilder = PostPostImageIdRangeBuilderFactory.Create([.. PostPostImages.Select(p => p.Id)]);
		PostPostImageIds = PostPostImageIdRangeBuilder.Build();
		PostPostImageResponses = PostPostImages.ToFullResponse();

		PostPostLikes = [.. Post.PostLikes];
		PostPostLikeIdRangeBuilderFactory = new();
		PostPostLikeIdRangeBuilder = PostPostLikeIdRangeBuilderFactory.Create([.. PostPostLikes.Select(p => p.Id)]);
		PostPostLikeIds = PostPostLikeIdRangeBuilder.Build();
		PostPostLikeResponses = PostPostLikes.ToFullResponse(CurrentUserId);

		PostPostComments = [.. Post.PostComments];
		PostPostCommentIdRangeBuilderFactory = new();
		PostPostCommentIdRangeBuilder = PostPostCommentIdRangeBuilderFactory.Create([.. PostPostComments.Select(p => p.Id)]);
		PostPostCommentIds = PostPostCommentIdRangeBuilder.Build();
		PostPostCommentResponses = PostPostComments.ToFullResponse(CurrentUserId);

		PostPostCommentsPostCommentImages = [.. Post.PostComments.SelectMany(p => p.PostCommentImages)];
		PostPostCommentsPostCommentImageIdRangeBuilderFactory = new();
		PostPostCommentsPostCommentImageIdRangeBuilder = PostPostCommentsPostCommentImageIdRangeBuilderFactory.Create([.. PostPostCommentsPostCommentImages.Select(p => p.Id)]);
		PostPostCommentsPostCommentImageIds = PostPostCommentsPostCommentImageIdRangeBuilder.Build();
		PostPostCommentsPostCommentImageResponses = PostPostCommentsPostCommentImages.ToFullResponse();

		PostPostCommentsPostCommentLikes = [.. Post.PostComments.SelectMany(p => p.PostCommentLikes)];
		PostPostCommentsPostCommentLikeIdRangeBuilderFactory = new();
		PostPostCommentsPostCommentLikeIdRangeBuilder = PostPostCommentsPostCommentLikeIdRangeBuilderFactory.Create([.. PostPostCommentsPostCommentLikes.Select(p => p.Id)]);
		PostPostCommentsPostCommentLikeIds = PostPostCommentsPostCommentLikeIdRangeBuilder.Build();
		PostPostCommentsPostCommentLikeResponses = PostPostCommentsPostCommentLikes.ToFullResponse(CurrentUserId);
	}
}
