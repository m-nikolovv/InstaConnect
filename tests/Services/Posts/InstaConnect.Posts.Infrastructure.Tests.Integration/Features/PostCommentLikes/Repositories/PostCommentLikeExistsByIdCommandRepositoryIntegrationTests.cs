using InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Repositories;

public class PostCommentLikeExistsByIdCommandRepositoryIntegrationTests : BasePostCommentLikeInfrastructureCommandIntegrationTest
{
	public PostCommentLikeExistsByIdCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostCommentLike, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(PostCommentLikeId, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikeId, postCommentLike);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(PostCommentLikeId, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikeId, postCommentLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentLikeIdBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, postCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentLikeIdBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, postCommentLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = PostCommentLikeIdBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, postCommentLike);
	}
}
