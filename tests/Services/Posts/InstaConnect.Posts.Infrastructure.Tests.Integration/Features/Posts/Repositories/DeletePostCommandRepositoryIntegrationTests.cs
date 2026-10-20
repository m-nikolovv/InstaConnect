namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class DeletePostCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	public DeletePostCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePost_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Post, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}
}
