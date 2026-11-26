
namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class AddPostCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	public AddPostCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupAddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPost_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(Post, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldSatisfy(Post);
	}
}
