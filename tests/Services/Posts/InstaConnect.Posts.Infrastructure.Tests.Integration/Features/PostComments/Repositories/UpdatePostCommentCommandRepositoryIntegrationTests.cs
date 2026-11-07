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
		await ServiceScope.AddAsync(PostComment, CancellationToken);
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

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedPostComment = PostCommentBuilderFactory.Create(Post, User).WithCommentId(PostCommentId).WithId(transformer).Build();

		// Act
		await Repository.UpdateAsync(updatedPostComment, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(updatedPostComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var updatedPostComment = PostCommentBuilderFactory.Create(Post, User).WithCommentId(PostCommentId, transformer).Build();

		// Act
		await Repository.UpdateAsync(updatedPostComment, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(updatedPostComment);
	}
}
