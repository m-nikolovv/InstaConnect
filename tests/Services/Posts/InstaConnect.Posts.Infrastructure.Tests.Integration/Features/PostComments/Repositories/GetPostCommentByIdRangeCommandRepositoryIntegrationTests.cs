using InstaConnect.Posts.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class GetPostCommentByIdRangeCommandRepositoryIntegrationTests : BasePostCommentInfrastructureCommandIntegrationTest
{
	private readonly PostCommentInclude _include;

	public GetPostCommentByIdRangeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPost().WithPostCommentImages().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(PostComments, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(PostCommentIds, _include, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(PostCommentIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComments);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostCommentIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComments);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndCommentIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostCommentIdRangeBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComments);
	}
}
