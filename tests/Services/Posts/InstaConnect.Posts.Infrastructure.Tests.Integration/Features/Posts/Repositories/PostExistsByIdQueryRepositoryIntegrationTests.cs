using InstaConnect.Posts.Tests.Features.Posts.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class PostExistsByIdQueryRepositoryIntegrationTests : BasePostInfrastructureQueryIntegrationTest
{
	public PostExistsByIdQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(PostId, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostId, post);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(PostId, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostId, post);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, post);
	}
}
