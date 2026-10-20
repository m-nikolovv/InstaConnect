using InstaConnect.Posts.Tests.Features.Posts.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class GetPostByIdCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	private readonly PostInclude _include;

	public GetPostByIdCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(PostId, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(PostId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostId, Post);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, Post);
	}
}
