using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Tests.Features.Common.Utilities;

public abstract class BasePostsTest : BaseTest
{
	protected UserBuilderFactory UserBuilderFactory { get; }
	protected UserBuilder UserBuilder { get; }
	protected User User { get; }
	protected ICollection<User> Users { get; }
	protected UserResponse UserResponse { get; }
	protected ICollection<UserResponse> UserResponses { get; }

	protected UserIdBuilderFactory UserIdBuilderFactory { get; }
	protected UserIdBuilder UserIdBuilder { get; }
	protected UserId UserId { get; }
	protected UserId CurrentUserId { get; }

	protected UserIdRangeBuilderFactory UserIdRangeBuilderFactory { get; }
	protected UserIdRangeBuilder UserIdRangeBuilder { get; }
	protected ICollection<UserId> UserIds { get; }

	protected PostBuilderFactory PostBuilderFactory { get; }
	protected PostBuilder PostBuilder { get; }
	protected Post Post { get; }
	protected ICollection<Post> Posts { get; }
	protected PostResponse PostResponse { get; }
	protected ICollection<PostResponse> PostResponses { get; }

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
	protected PostLikeResponse PostLikeResponse { get; }
	protected ICollection<PostLikeResponse> PostLikeResponses { get; }

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
	protected PostImageResponse PostImageResponse { get; }
	protected ICollection<PostImageResponse> PostImageResponses { get; }

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
	protected PostCommentResponse PostCommentResponse { get; }
	protected ICollection<PostCommentResponse> PostCommentResponses { get; }

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
	protected PostCommentImageResponse PostCommentImageResponse { get; }
	protected ICollection<PostCommentImageResponse> PostCommentImageResponses { get; }

	protected PostCommentImageIdBuilderFactory PostCommentImageIdBuilderFactory { get; }
	protected PostCommentImageIdBuilder PostCommentImageIdBuilder { get; }
	protected PostCommentImageId PostCommentImageId { get; }

	protected PostCommentImageIdRangeBuilderFactory PostCommentImageIdRangeBuilderFactory { get; }
	protected PostCommentImageIdRangeBuilder PostCommentImageIdRangeBuilder { get; }
	protected ICollection<PostCommentImageId> PostCommentImageIds { get; }

	protected PostCommentLikeBuilderFactory PostCommentLikeBuilderFactory { get; }
	protected PostCommentLikeBuilder PostCommentLikeBuilder { get; }
	protected PostCommentLike PostCommentLike { get; }
	protected ICollection<PostCommentLike> PostCommentLikes { get; }
	protected PostCommentLikeResponse PostCommentLikeResponse { get; }
	protected ICollection<PostCommentLikeResponse> PostCommentLikeResponses { get; }

	protected PostCommentLikeIdBuilderFactory PostCommentLikeIdBuilderFactory { get; }
	protected PostCommentLikeIdBuilder PostCommentLikeIdBuilder { get; }
	protected PostCommentLikeId PostCommentLikeId { get; }

	protected PostCommentLikeIdRangeBuilderFactory PostCommentLikeIdRangeBuilderFactory { get; }
	protected PostCommentLikeIdRangeBuilder PostCommentLikeIdRangeBuilder { get; }
	protected ICollection<PostCommentLikeId> PostCommentLikeIds { get; }

	protected BasePostsTest()
	{
		UserBuilderFactory = new();
		UserBuilder = UserBuilderFactory.Create();
		User = UserBuilder.Build();
		Users = User.Generate();
		UserResponse = User.ToFullResponse();
		UserResponses = Users.ToFullResponse();

		UserIdBuilderFactory = new();
		UserIdBuilder = UserIdBuilderFactory.Create(User.Id);
		UserId = UserIdBuilder.Build();
		CurrentUserId = UserId;

		UserIdRangeBuilderFactory = new();
		UserIdRangeBuilder = UserIdRangeBuilderFactory.Create([.. Users.Select(p => p.Id)]);
		UserIds = UserIdRangeBuilder.Build();

		PostBuilderFactory = new();
		PostBuilder = PostBuilderFactory.Create(User);
		Post = PostBuilder.BuildAttached();
		Posts = Post.GenerateAttached(Users);
		PostResponse = Post.ToFullResponse(CurrentUserId);
		PostResponses = Posts.ToFullResponse(CurrentUserId);

		PostIdBuilderFactory = new();
		PostIdBuilder = PostIdBuilderFactory.Create(Post.Id);
		PostId = PostIdBuilder.Build();

		PostIdRangeBuilderFactory = new();
		PostIdRangeBuilder = PostIdRangeBuilderFactory.Create([.. Posts.Select(p => p.Id)]);
		PostIds = PostIdRangeBuilder.Build();

		PostLikeBuilderFactory = new();
		PostLikeBuilder = PostLikeBuilderFactory.Create(Post, User);
		PostLike = PostLikeBuilder.BuildAttached();
		PostLikes = PostLike.GenerateAttached(Posts, Users);
		PostLikeResponse = PostLike.ToFullResponse(CurrentUserId);
		PostLikeResponses = PostLikes.ToFullResponse(CurrentUserId);

		PostLikeIdBuilderFactory = new();
		PostLikeIdBuilder = PostLikeIdBuilderFactory.Create(PostLike.Id);
		PostLikeId = PostLikeIdBuilder.Build();

		PostLikeIdRangeBuilderFactory = new();
		PostLikeIdRangeBuilder = PostLikeIdRangeBuilderFactory.Create([.. PostLikes.Select(p => p.Id)]);
		PostLikeIds = PostLikeIdRangeBuilder.Build();

		PostImageBuilderFactory = new();
		PostImageBuilder = PostImageBuilderFactory.Create(Post);
		PostImage = PostImageBuilder.BuildAttached();
		PostImages = PostImage.GenerateAttached(Posts);
		PostImageResponse = PostImage.ToFullResponse();
		PostImageResponses = PostImages.ToFullResponse();

		PostImageIdBuilderFactory = new();
		PostImageIdBuilder = PostImageIdBuilderFactory.Create(PostImage.Id);
		PostImageId = PostImageIdBuilder.Build();

		PostImageIdRangeBuilderFactory = new();
		PostImageIdRangeBuilder = PostImageIdRangeBuilderFactory.Create([.. PostImages.Select(p => p.Id)]);
		PostImageIds = PostImageIdRangeBuilder.Build();

		PostCommentBuilderFactory = new();
		PostCommentBuilder = PostCommentBuilderFactory.Create(Post, User);
		PostComment = PostCommentBuilder.BuildAttached();
		PostComments = PostComment.GenerateAttached(Posts, Users);
		PostCommentResponse = PostComment.ToFullResponse(CurrentUserId);
		PostCommentResponses = PostComments.ToFullResponse(CurrentUserId);

		PostCommentIdBuilderFactory = new();
		PostCommentIdBuilder = PostCommentIdBuilderFactory.Create(PostComment.Id);
		PostCommentId = PostCommentIdBuilder.Build();

		PostCommentIdRangeBuilderFactory = new();
		PostCommentIdRangeBuilder = PostCommentIdRangeBuilderFactory.Create([.. PostComments.Select(p => p.Id)]);
		PostCommentIds = PostCommentIdRangeBuilder.Build();

		PostCommentImageBuilderFactory = new();
		PostCommentImageBuilder = PostCommentImageBuilderFactory.Create(PostComment);
		PostCommentImage = PostCommentImageBuilder.BuildAttached();
		PostCommentImages = PostCommentImage.GenerateAttached(PostComments);
		PostCommentImageResponse = PostCommentImage.ToFullResponse();
		PostCommentImageResponses = PostCommentImages.ToFullResponse();

		PostCommentImageIdBuilderFactory = new();
		PostCommentImageIdBuilder = PostCommentImageIdBuilderFactory.Create(PostCommentImage.Id);
		PostCommentImageId = PostCommentImageIdBuilder.Build();

		PostCommentImageIdRangeBuilderFactory = new();
		PostCommentImageIdRangeBuilder = PostCommentImageIdRangeBuilderFactory.Create([.. PostCommentImages.Select(p => p.Id)]);
		PostCommentImageIds = PostCommentImageIdRangeBuilder.Build();

		PostCommentLikeBuilderFactory = new();
		PostCommentLikeBuilder = PostCommentLikeBuilderFactory.Create(PostComment, User);
		PostCommentLike = PostCommentLikeBuilder.BuildAttached();
		PostCommentLikes = PostCommentLike.GenerateAttached(PostComments, Users);
		PostCommentLikeResponse = PostCommentLike.ToFullResponse(CurrentUserId);
		PostCommentLikeResponses = PostCommentLikes.ToFullResponse(CurrentUserId);

		PostCommentLikeIdBuilderFactory = new();
		PostCommentLikeIdBuilder = PostCommentLikeIdBuilderFactory.Create(PostCommentLike.Id);
		PostCommentLikeId = PostCommentLikeIdBuilder.Build();

		PostCommentLikeIdRangeBuilderFactory = new();
		PostCommentLikeIdRangeBuilder = PostCommentLikeIdRangeBuilderFactory.Create([.. PostCommentLikes.Select(p => p.Id)]);
		PostCommentLikeIds = PostCommentLikeIdRangeBuilder.Build();
	}
}
