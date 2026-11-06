using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class AddPostLikeCommandRepositoryIntegrationTests : BasePostLikeInfrastructureCommandIntegrationTest
{
	public AddPostLikeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.DeleteAsync(PostLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostLike_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostLike, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(PostLike);
	}
}
