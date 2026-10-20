namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class DeletePostCommentCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	public DeletePostCommentCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostComment_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostComment, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(PostCommentId, CancellationToken);

		// Assert
		postComment.ShouldBeNull();
	}
}
