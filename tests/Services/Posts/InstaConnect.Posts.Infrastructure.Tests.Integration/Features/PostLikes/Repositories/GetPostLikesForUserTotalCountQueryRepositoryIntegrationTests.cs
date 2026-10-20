using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class GetPostLikesForUserTotalCountQueryRepositoryIntegrationTests : BasePostLikeInfrastructureQueryIntegrationTest
{
	private readonly PostLikesForUserFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostLikesForUserFilterQueryBuilder _filterQueryBuilder;
	private readonly PostLikesForUserFilterQuery _filterQuery;

	public GetPostLikesForUserTotalCountQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostLike);
		_filterQuery = _filterQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, PostLikes);
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
		response.ShouldSatisfy(filterQuery, PostLikes);
	}
}
