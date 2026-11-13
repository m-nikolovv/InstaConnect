using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class GetPostLikeByIdRangeCommandRepositoryIntegrationTests : BasePostLikeInfrastructureCommandIntegrationTest
{
	private readonly PostLikeInclude _include;

	public GetPostLikeByIdRangeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPost().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(PostLikes, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(PostLikeIds, _include, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(PostLikeIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikes);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostLikeIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikes);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndUserIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostLikeIdRangeBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikes);
	}
}
