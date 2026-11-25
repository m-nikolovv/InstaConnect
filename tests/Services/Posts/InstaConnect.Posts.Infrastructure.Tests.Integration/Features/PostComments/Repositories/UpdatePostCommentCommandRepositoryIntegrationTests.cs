using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class UpdatePostCommentCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	public UpdatePostCommentCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostComment, CurrentUserId, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandIsValid()
	{
		var updatedPostComment = PostCommentBuilderFactory.Create(Post, User).WithCommentId(PostCommentId).Build();

		// Act
		await Repository.UpdateAsync(updatedPostComment, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(updatedPostComment);
	}

	[Fact]
	public async Task UpdateAsync_ShouldDeleteCachedPostComment_WhenCommandIsValid()
	{
		// Arrange
		var updatedPostComment = PostCommentBuilderFactory.Create(Post, User).WithCommentId(PostCommentId).Build();

		// Act
		await Repository.UpdateAsync(updatedPostComment, CancellationToken);
		var cachedPostComment = await CommentCacheHandler.GetByIdAsync(updatedPostComment, CurrentUserId, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}
}
