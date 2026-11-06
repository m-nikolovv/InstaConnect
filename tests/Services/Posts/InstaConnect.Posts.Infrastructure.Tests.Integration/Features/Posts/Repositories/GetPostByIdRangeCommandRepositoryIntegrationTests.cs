namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class GetPostByIdRangeCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	private readonly PostInclude _include;

	public GetPostByIdRangeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(UserPosts, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(UserPostIds, _include, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(UserPostIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserPosts);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = UserPostIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(UserPosts);
	}
}
