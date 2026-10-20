using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Repositories;

public class GetPostCommentLikesForUserTotalCountQueryRepositoryIntegrationTests : BasePostCommentLikeInfrastructureQueryIntegrationTest
{
	private readonly PostCommentLikesForUserFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostCommentLikesForUserFilterQueryBuilder _filterQueryBuilder;
	private readonly PostCommentLikesForUserFilterQuery _filterQuery;

	public GetPostCommentLikesForUserTotalCountQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostCommentLike);
		_filterQuery = _filterQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, PostCommentLikes);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetTotalCountForUserAsync_ShouldReturnResponse_WhenQueryAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountForUserAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, PostCommentLikes);
	}
}
