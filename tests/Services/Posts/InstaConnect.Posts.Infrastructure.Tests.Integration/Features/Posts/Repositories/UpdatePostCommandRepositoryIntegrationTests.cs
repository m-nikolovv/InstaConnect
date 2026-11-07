namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class UpdatePostCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	public UpdatePostCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePost_WhenCommandIsValid()
	{
		var updatedPost = PostBuilderFactory.Create(User).WithId(PostId).Build();

		// Act
		await Repository.UpdateAsync(updatedPost, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldSatisfy(updatedPost);
	}
}
