using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Repositories;

public class AddPostCommentLikeCommandRepositoryIntegrationTests : BasePostCommentLikeInfrastructureCommandIntegrationTest
{
	public AddPostCommentLikeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.DeleteAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostCommentLike, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(PostCommentLike);
	}
}
