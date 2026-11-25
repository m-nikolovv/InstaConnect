using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Repositories;

public class GetPostCommentLikeByIdRangeCommandRepositoryIntegrationTests : BasePostCommentLikeInfrastructureCommandIntegrationTest
{
	private readonly PostCommentLikeInclude _include;

	public GetPostCommentLikeByIdRangeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPostComment().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnEmpty_WhenIdsAreInvalid()
	{
		// Arrange
		await ServiceScope.DeleteRangeAsync(PostCommentLikes, CancellationToken);

		// Act
		var response = await Repository.GetByIdRangeAsync(PostCommentLikeIds, _include, CancellationToken);

		// Assert
		response.ShouldBeEmpty();
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdRangeAsync(PostCommentLikeIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikes);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostCommentLikeIdRangeBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikes);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndCommentIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostCommentLikeIdRangeBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikes);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandAndUserIdsAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var ids = PostCommentLikeIdRangeBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Repository.GetByIdRangeAsync(ids, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikes);
	}
}
