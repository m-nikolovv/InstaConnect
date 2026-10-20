using InstaConnect.Posts.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class PostLikeExistsByIdCommandRepositoryIntegrationTests : BasePostLikeInfrastructureCommandIntegrationTest
{
	public PostLikeExistsByIdCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostLike, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostLike, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(PostLikeId, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, postLike);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(PostLikeId, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, postLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostLikeIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, postLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostLikeIdBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, postLike);
	}
}
