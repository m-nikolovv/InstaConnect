using InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostComments.Repositories;

public class GetPostCommentsTotalCountQueryRepositoryIntegrationTests : BasePostCommentInfrastructureQueryIntegrationTest
{
	private readonly PostCommentsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostCommentsFilterQueryBuilder _filterQueryBuilder;
	private readonly PostCommentsFilterQuery _filterQuery;

	public GetPostCommentsTotalCountQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostComment);
		_filterQuery = _filterQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, PostComments);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, PostComments);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithUserName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, PostComments);
	}
}
